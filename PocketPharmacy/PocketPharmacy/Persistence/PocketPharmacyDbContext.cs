using Microsoft.EntityFrameworkCore;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Persistence
{
    public class PocketPharmacyDbContext : DbContext
    {
        public DbSet<Dosage> Dosages { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<User> Users { get; set; }

        public PocketPharmacyDbContext(DbContextOptions<PocketPharmacyDbContext> options)
            : base(options)
        {
        }
    }
}
