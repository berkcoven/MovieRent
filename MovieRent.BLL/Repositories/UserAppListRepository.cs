using MovieRent.BLL.Singleton;
using MovieRent.DAL;
using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieRent.BLL.Repositories
{
    public class UserAppListRepository:BaseRepository<UserAppFilmList>
    {

        private ProjectContext db;
        public UserAppListRepository()
        {
            db = DbTool.DbInstance;
        }

        public void ListeSil(UserAppFilmList userAppFilmList)
        {

            userAppFilmList.isActive = false;
            db.SaveChanges();
        }

        public void UpdateByID(UserAppFilmList userAppFilmList, int i)
        {
            
            userAppFilmList.Oncelik = (short)(i+1);
            db.SaveChanges();

        }
        public UserAppFilmList SelectByOncelikID(int id)
        {
            return db.Set<UserAppFilmList>().Where(x => x.Oncelik == id).FirstOrDefault();
        }
     
        public void ListAddById(Movies movie,UserApp user)
        {
            int i = db.Set<UserAppFilmList>().Where(x => x.UserID == user.UserID&&x.isActive==true).Count();

            UserAppFilmList userlist = new UserAppFilmList();
            userlist.isActive = true;
            userlist.ListeTarihi = DateTime.Now;
            userlist.MovieID = movie.MovieID;
            userlist.MovieName = movie.MovieName;
            userlist.UserID = user.UserID;
            userlist.Oncelik =(short) (i + 1);
            

            Add(userlist);

        }

        public List<UserAppFilmList> NextDayAlgo(List<UserAppFilmList> uaps,List<Movies> movies)
        {
            DateTime dt = DateTime.Now;
            List<UserAppFilmList> shortstock = new List<UserAppFilmList>();
            List<UserAppFilmList> gonderilecek = new List<UserAppFilmList>();
           
            //Stokta istenilen kadar ürün var mı ..
            foreach (var item in uaps)
            {
                Movies a = movies.Where(x => x.MovieID == item.MovieID).FirstOrDefault();
                if (uaps.Where(x => x.MovieID == item.MovieID).Count() > a.Stock)
                {
                    //TOOD::if(group by kullanıcı liste :/)
                    shortstock.Add(item);

                }
                else
                {
                    gonderilecek.Add(item);
                }

            }
            //puan hesaplama
            List<UserAppFilmList> shortstockGonderilecek = new List<UserAppFilmList>();
            foreach (var item in shortstock)
            {
                DateTime listDate = item.ListeTarihi.Value;
                TimeSpan span = dt - listDate;
                double fark = span.TotalDays;
                double gunPuan = fark / 3;
                item.point = (double)(11- item.Oncelik);
                item.point += gunPuan;
                db.SaveChanges();
                
            }
            foreach (var item in gonderilecek)
            {
                DateTime listDate = item.ListeTarihi.Value;
                TimeSpan span = dt - listDate;
                double fark = span.TotalDays;
                double gunPuan = fark / 3;
                item.point = (double)(11- item.Oncelik);
                item.point += gunPuan;
                db.SaveChanges();
                
            }
            //puanı yüksek olanı üste alsın
            shortstockGonderilecek = shortstock.OrderByDescending(x => x.point).ToList();
            //movieID si x olan bir üründen stok sayısı kadar ürünü listeye eklesin
            //take<> ile en üstte kalanları yani puanı yüksek olanları alsın.
            for (int i = 0; i < shortstockGonderilecek.Count; i++)
            {
                Movies a = movies.Where(x => x.MovieID == shortstockGonderilecek[i].MovieID).FirstOrDefault();
                List<UserAppFilmList> gL = shortstockGonderilecek.Where(x => x.MovieID == shortstockGonderilecek[i].MovieID).Take((int)a.Stock).ToList();
                shortstockGonderilecek.RemoveAll(x => x.MovieID == shortstockGonderilecek[i].MovieID);
                foreach (var item2 in gL)
                {
                    gonderilecek.Add(item2);
                }

            }
            UserAppRepository ua = new UserAppRepository();
            List<UserAppFilmList> gonderSayi = new List<UserAppFilmList>();
            List<UserAppFilmList> gonderFinal = new List<UserAppFilmList>();
            foreach (var item in gonderilecek)
            {
                gonderSayi.Add(item);
            }
            gonderSayi = gonderSayi.OrderByDescending(x => x.point).ToList();

            foreach (var item in gonderSayi)
            {
                UserApp us = ua.SelectAll().Where(x => x.UserID == item.UserID).FirstOrDefault();
                if (ua.UserFilmTimes(us))
                {
                   
                    item.isSent = true;
                    Update(item.ListID, item);
                    
                    gonderFinal.Add(item);
                }
            }


            return gonderFinal;

        }
    }
}
