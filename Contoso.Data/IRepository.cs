using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Data
{
   // T can be any class. cannot be int or other primitive type
   public interface IRepository<T> where T: class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int Id);
        IEnumerable<T> GetAll();
        T GetById(int Id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> expression);
        IQueryable<T> GetQuerable();
        // for transactions
        void SaveChanges();

    }
}
