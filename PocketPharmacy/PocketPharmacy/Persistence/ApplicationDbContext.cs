using Microsoft.EntityFrameworkCore;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Dosage> Dosages { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
