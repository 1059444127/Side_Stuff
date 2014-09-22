using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Puteshestvenici.Data.Repositories
{
    public class Repository<T> : IGenericRepository<T> where T : class
    {
        private IPuteshestveniciDbContext dbContext;

        public Repository(IPuteshestveniciDbContext atmDbContext)
        {
            this.dbContext = atmDbContext;
        }

        public Repository()
            : this(new PuteshestveniciDbContext())
        {
        }

        public IQueryable<T> GetAll()
        {
            return this.dbContext.Set<T>();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.GetAll().Where(expression);
        }

        public void Add(T entry)
        {
            this.dbContext.Set<T>().Add(entry);
        }

        public T Remove(T entry)
        {
            this.SetState(entry, EntityState.Deleted);
            return entry;
        }

        public void Update(T entry)
        {
            this.SetState(entry, EntityState.Modified);
        }

        public void Detach(T entry)
        {
            this.SetState(entry, EntityState.Detached);
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private void SetState(T entry, EntityState state)
        {
            this.dbContext.Set<T>().Attach(entry);
            this.dbContext.Entry(entry).State = state;
        }
    }
}
