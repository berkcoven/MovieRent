using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRent.Entities
{
    public class Movies : BaseEntity
    {
        [Key]
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string CrMovieName { get; set; }

        public Nullable<short> Stock { get; set; }
        public int CategoryID { get; set; }
        public Nullable<int> ListID { get; set; }
        public Nullable<int> AdminID { get; set; }

        public string Director { get; set; }
        public string Actors { get; set; }
        public Nullable<DateTime> RelaiseDate { get; set; }
        public string AudioProperty { get; set; }
        public string Awards { get; set; }
        public Nullable<int> Barkodno { get; set; }
        public string Altyazi { get; set; }

        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
       



        public virtual ICollection<Categories> Categories { get; set; }
        public List<UserAppFilmList> UserList { get; set; }
        
        


    }
}
