using Microsoft.EntityFrameworkCore;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Persistence
{
    public class PocketPharmacyDbContext : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<User> Users { get; set; }

        public PocketPharmacyDbContext(DbContextOptions<PocketPharmacyDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;database=pocketpharmacy;uid=root;password=;port=3306");
        }
    }
}
