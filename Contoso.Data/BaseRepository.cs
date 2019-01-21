using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Contoso.Data
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly IDbSet<T> DbSet;
        protected ContosoDbContext ContosoDbContext;

        //constructor
        public BaseRepository(ContosoDbContext contosoDbContext)
        {
            ContosoDbContext = contosoDbContext;
            DbSet = ContosoDbContext.Set<T>();
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(int id)
        {
            DbSet.Attach(DbSet.Find(id));
            DbSet.Remove(DbSet.Find(id));
        }


        public IEnumerable<T> GetAll()
        {
            //return DbSet.ToList();
            return DbSet;
        }

        public T GetById(int Id)
        {
            return DbSet.Find(Id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        // can use skip and take in IQueryable. IEnumerable cannot use them
        public IQueryable<T> GetQuerable()
        {
            return DbSet.AsQueryable();
        }

        public void SaveChanges()
        {
            ContosoDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            ContosoDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
