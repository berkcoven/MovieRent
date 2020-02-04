using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRent.Entities
{
    public class  Premiums : BaseEntity
    {
        [Key]
        public int PremiumID { get; set; }
        public string PremiumName { get; set; }
        public decimal Price { get; set; }
        public int RentTimes { get; set; }

    }
}
