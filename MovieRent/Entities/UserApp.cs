using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRent.Entities
{
    public class UserApp : BaseEntity
    {
        
        public UserApp()
        {
            
            UyeOlmeTarihi = DateTime.Now;
            NotDeliverTimes = 0;
        }
        [Key]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserLastName { get; set; }
        [Required]
        public string Sifre { get; set; }
        [Required]
        public string KKNo { get; set; }
        [Required]
        public string KKSonKullanma { get; set; }
        [Required]
        public int KKSifre { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string TelNo { get; set; }
        public DateTime UyeOlmeTarihi { get; set; }
        public int NotDeliverTimes { get; set; }


        public UserAppFilmList UserMovieList { get; set; }
        public Premiums Userpremium { get; set; }
    }
}
