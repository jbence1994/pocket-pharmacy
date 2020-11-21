using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;

namespace PocketPharmacy.Persistence.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicineRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Medicine> GetMedicines(int userId)
        {
            return _context.Medicines
                .Include(m => m.Dosage)
                .Where(m => m.UserId == userId).ToList();
        }

        public Medicine GetMedicine(int userId, int medicineId)
        {
            var medicine = GetMedicines(userId)
                .SingleOrDefault(m => m.Id == medicineId);

            if (medicine == null)
                throw new Exception("Nem létező gyógyszer.");

            return medicine;
        }

        public void AddMedicine(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
        }

        public void DeleteMedicine(int userId, int id)
        {
            var medicine = GetMedicine(userId, id);

            _context.Medicines.Remove(medicine);
        }
    }
}
