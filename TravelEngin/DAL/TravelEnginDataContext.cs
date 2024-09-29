using TravelEngin.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelEngin.DAL
{
    public class TravelEnginDataContext : DbContext
    {

        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }

        public TravelEnginDataContext()
        {
            
        }
       
       
       protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
          options.UseSqlite($"Data Source=TravelEngin.db");
        }

        public void Initialize()
        {
            // Apply any pending migrations and ensure the database is up to date
            Database.EnsureCreated();
        }
    }
}