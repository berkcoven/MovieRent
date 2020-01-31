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


        
            
    }
}
