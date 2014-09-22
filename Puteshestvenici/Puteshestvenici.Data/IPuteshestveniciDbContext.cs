using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using Puteshestvenici.Models;

namespace Puteshestvenici.Data
{
    public interface IPuteshestveniciDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Trip> Trips { get; set; }

        IDbSet<Location> Locations { get; set; }

        DbContextConfiguration Configuration { get; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
