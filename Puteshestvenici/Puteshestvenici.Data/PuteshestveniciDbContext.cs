using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using Puteshestvenici.Data.Migrations;
using Puteshestvenici.Models;

namespace Puteshestvenici.Data
{
    public class PuteshestveniciDbContext : IdentityDbContext<ApplicationUser>, IPuteshestveniciDbContext
    {
        public static PuteshestveniciDbContext Create()
        {
            return new PuteshestveniciDbContext();
        }

        public PuteshestveniciDbContext()
            : base("PuteshestveniciConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PuteshestveniciDbContext, Configuration>());
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Trip> Trips { get; set; }

        public virtual IDbSet<Location> Locations { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trip>()
                        .HasRequired(t => t.From)
                        .WithMany(l => l.FromTrip)
                        .HasForeignKey(t => t.FromLocationID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>()
                        .HasRequired(t => t.To)
                        .WithMany(l => l.ToTrip)
                        .HasForeignKey(t => t.ToLocationID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>()
                        .HasRequired(t => t.User)
                        .WithMany(u => u.Trips)
                        .HasForeignKey(t => t.UserID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                        .HasMany(u => u.TripsAsPassenger)
                        .WithMany(t => t.Passengers)
                        .Map(m =>
                        {
                            m.ToTable("TripsPassengers");
                            m.MapLeftKey("UserID");
                            m.MapRightKey("TripID");
                        });
        }
    }
}
