using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRent.DAL;

namespace MovieRent.BLL.Singleton
{
    public class DbTool
    {
        private static ProjectContext _dbInstance;

        public static ProjectContext DbInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new ProjectContext();
                }
                return _dbInstance;
            }
        }

    }
}
