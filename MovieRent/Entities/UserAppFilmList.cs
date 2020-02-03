using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRent.Entities
{
    public class UserAppFilmList:BaseEntity
    {
        public UserAppFilmList()
        {
            isActive = true;
            isSent = false;
            
        }
      
        [Key]
        public int ListID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public string MovieName { get; set; }

        public bool isActive { get; set; }

        public Nullable<DateTime> KiralaTarihi { get; set; }
        public Nullable<DateTime> ListeTarihi { get; set; }
        public Nullable<short> Oncelik { get; set; }
        public double point { get; set; }
        public bool isSent { get; set; }
        public string CarrierName { get; set; }

        public List<UserApp> userApp { get; set; }
        public List<Movies> MovieList { get; set; }
    }
}
