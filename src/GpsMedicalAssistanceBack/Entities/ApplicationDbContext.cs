using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Change decimal precision
            modelBuilder.Entity<FavoritePlace>().Property(x => x.Latitude).HasPrecision(12, 9);
            modelBuilder.Entity<FavoritePlace>().Property(x => x.Longitude).HasPrecision(12, 9);
            modelBuilder.Entity<Alert>().Property(x => x.CurrentLocationLatitude).HasPrecision(12, 9);
            modelBuilder.Entity<Alert>().Property(x => x.CurrentLocationLongitude).HasPrecision(12, 9);
            modelBuilder.Entity<Alert>().Property(x => x.DestinationLocationLatitude).HasPrecision(12, 9);
            modelBuilder.Entity<Alert>().Property(x => x.DestinationLocationLongitude).HasPrecision(12, 9);

            modelBuilder.ApplyConfiguration(new FamilyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AlertUserTypeConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyType> FamilyTypes { get; set; }
        public DbSet<FavoritePlace> FavoritePlaces { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<AlertUser> AlertUsers { get; set; }
        public DbSet<AlertUserType> AlertUserTypes { get; set; }
        public DbSet<UserAnonymous> UserAnonymous { get; set; }
    }
}
