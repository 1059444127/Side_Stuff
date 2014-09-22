using System.Data.Entity.Infrastructure;

using Puteshestvenici.Data.Repositories;
using Puteshestvenici.Models;

namespace Puteshestvenici.Data
{
    public interface IPuteshestveniciData
    {
        IGenericRepository<User> Users { get; }

        IGenericRepository<Trip> Trips { get; }

        IGenericRepository<Location> Locations { get; }

        DbContextConfiguration Configuration { get; }

        int SaveChanges();
    }
}
