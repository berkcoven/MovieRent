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
    }
}
