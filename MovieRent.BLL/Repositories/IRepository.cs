using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRent.BLL.Repositories
{
   public interface IRepository<T> where T:BaseEntity
    {
        void Add(T item);
        void Delete(T item);
        void Update(int id,T item);
        List<T> SelectAll();
        List<T> Where(Expression<Func<T, bool>> exp);
        T SelectByID(int id);
        bool Any(Expression<Func<T, bool>> exp);
    }
}
