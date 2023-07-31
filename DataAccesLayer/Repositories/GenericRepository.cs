using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();
        public void Delete(T t)
        {
           c.Remove(t);
           c.SaveChanges();
        }

        public List<T> GetAll()
        {
            return c.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return c.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            c.Add(t);
            c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
          return c.Set<T>().Where(filter).ToList(); 
        }

        public void Update(T t)
        {
           c.Update (t);
           c.SaveChanges();    
        }
    }
}
