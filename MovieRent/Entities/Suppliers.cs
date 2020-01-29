using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRent.Entities
{
    public class Suppliers:BaseEntity
    {
        [Key]
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }

        public List<Movies> Movies { get; set; }
    }
}
