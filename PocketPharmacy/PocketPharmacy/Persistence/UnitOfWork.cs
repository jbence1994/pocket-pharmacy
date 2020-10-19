using PocketPharmacy.Core;

namespace PocketPharmacy.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PocketPharmacyDbContext _context;

        public UnitOfWork(PocketPharmacyDbContext context)
        {
            _context = context;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
