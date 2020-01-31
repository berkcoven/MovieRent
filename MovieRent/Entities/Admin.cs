using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRent.Entities
{
    public class Admin : BaseEntity
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminSifre { get; set; }
        public string AdminEmail { get; set; }
        public List<Movies> EditorSecim { get; set; }
    }
}
