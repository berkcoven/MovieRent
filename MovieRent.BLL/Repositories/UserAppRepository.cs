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
    public class UserAppRepository:BaseRepository<UserApp>
    {
        private ProjectContext db;
        public UserAppRepository()
        {
            db = DbTool.DbInstance;
        }

        public void UserActivate(int id)
        {
            UserApp user = SelectByID(id);
            user.isActive = true;

            db.SaveChanges();
        }
        public bool UserFilmTimes(UserApp user)
        {
            PremiumRepository pr = new PremiumRepository();
            UserAppListRepository ualp = new UserAppListRepository();
            var prem = pr.SelectAll().Where(x => x.PremiumID == user.Userpremium.PremiumID).FirstOrDefault();
            int userfilm = ualp.SelectAll().Where(x => x.UserID == user.UserID&&x.isSent==true).Count();
            if (userfilm < prem.RentTimes)
            {
                
                return true;
            }
            else
            {
                return false;
            }
            
        }


        
            
    }
}
