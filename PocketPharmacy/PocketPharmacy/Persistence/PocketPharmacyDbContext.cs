using Microsoft.EntityFrameworkCore;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Persistence
{
    public class PocketPharmacyDbContext : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }

        public PocketPharmacyDbContext(DbContextOptions<PocketPharmacyDbContext> options)
            : base(options)
        {
        }
    }
}
