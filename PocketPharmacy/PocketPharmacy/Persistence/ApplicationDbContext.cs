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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>()
                .HasOne<Dosage>(m => m.Dosage)
                .WithOne(d => d.Medicine)
                .HasForeignKey<Dosage>(d => d.MedicineId);

            modelBuilder.Entity<Medicine>()
                .HasOne<User>(m => m.User)
                .WithMany(u => u.Medicines)
                .HasForeignKey(m => m.UserId);
        }
    }
}
