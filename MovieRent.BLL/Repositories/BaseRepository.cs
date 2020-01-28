using MovieRent.BLL.Singleton;
using MovieRent.DAL;
using MovieRent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRent.BLL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private ProjectContext db;
        public BaseRepository()
        {
            db = DbTool.DbInstance;
        }


        public void Add(T item)
        {
            db.Set<T>().Add(item);
            db.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            //db.Set<T>().Remove(item);
            db.SaveChanges();
        }

        public List<T> SelectAll()
        {
            return db.Set<T>().ToList();
        }
            
        public T SelectByID(int id)
        {
            return db.Set<T>().Find(id);
        }  

        public void Update(int id,T item)
        {

            T update = SelectByID(id);
            db.Entry(update).CurrentValues.SetValues(item);
            db.SaveChanges();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }

    }
}
