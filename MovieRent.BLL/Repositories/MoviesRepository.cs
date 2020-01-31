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
    public class MoviesRepository:BaseRepository<Movies>
    {
        private ProjectContext db;
        public MoviesRepository()
        {
            db = DbTool.DbInstance;
        }
        public void KiralaTarihi(List<UserAppFilmList> uap,DateTime dt)
        {

            foreach (UserAppFilmList item in uap)
            {
                item.KiralaTarihi = dt;
                db.SaveChanges();
            }
           
        }
        public Movies SelectMovieByName(string name)
        {
            return SelectAll().Where(x => x.MovieName == name).FirstOrDefault();
        }

        public void AddtoEditorList(Movies mv)
        {
            mv.AdminID = 1;
            db.SaveChanges();
        }
        public void RemoveFromEditorList(Movies mv)
        {
            mv.AdminID = null;
            db.SaveChanges();
        }



    }
}
