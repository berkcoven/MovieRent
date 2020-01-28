using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MovieRent.Entities;

namespace MovieRent.MAP
{
   public class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
    }
}
