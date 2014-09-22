using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

using Puteshestvenici.Data.Repositories;
using Puteshestvenici.Models;

namespace Puteshestvenici.Data
{
    public class PuteshestveniciData : IPuteshestveniciData
    {
        private IPuteshestveniciDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public PuteshestveniciData()
            : this(new PuteshestveniciDbContext())
        {
        }

        public PuteshestveniciData(IPuteshestveniciDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IGenericRepository<Trip> Trips
        {
            get
            {
                return this.GetRepository<Trip>();
            }
        }

        public IGenericRepository<Location> Locations
        {
            get
            {
                return this.GetRepository<Location>();
            }
        }

        public DbContextConfiguration Configuration
        {
            get
            {
                return this.dbContext.Configuration;
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var repoType = typeof(Repository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(repoType, this.dbContext));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
