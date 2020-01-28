using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRent.MAP.Options
{
    public class UserAppMap:BaseMap<UserApp>
    {   
        public UserAppMap()
        {
            ToTable("User");
        }
    }
}
