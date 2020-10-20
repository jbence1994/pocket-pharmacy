using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;

namespace PocketPharmacy.Persistence
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly PocketPharmacyDbContext _context;

        public MedicineRepository(PocketPharmacyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Medicine> GetMedicines(int userId)
        {
            return _context.Medicines
                .Include(m => m.Dosage)
                .Where(m => m.UserId == userId).ToList();
        }

        private IEnumerable<Medicine> GetMedicines()
        {
            return _context.Medicines
                .Include(m => m.Dosage)
                .ToList();
        }

        public Medicine GetMedicine(int userId, int medicineId)
        {
            var medicine = GetMedicines(userId)
                .SingleOrDefault(m => m.Id == medicineId);

            if (medicine == null)
                throw new Exception("Nem létező gyógyszer.");

            return medicine;
        }

        public Medicine GetMedicine(int medicineId)
        {
            var medicine = GetMedicines().SingleOrDefault(m => m.Id == medicineId);

            if (medicine == null)
                throw new Exception("Nem létező gyógyszer.");

            return medicine;
        }

        public void AddMedicine(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
        }

        public void DeleteMedicine(int id)
        {
            var medicine = GetMedicine(id);

            if (medicine == null)
                throw new Exception("Nem létező gyógyszer.");

            _context.Medicines.Remove(medicine);
        }

        public double GetWeeklyDosage(int id)
        {
            var medicine = GetMedicine(id);

            return medicine.GetWeeklyDosage();
        }

        public bool IsExpiredMedicine(int id)
        {
            var medicine = GetMedicine(id);

            return medicine.IsExpired();
        }

        public bool HasWeeklyDosage(int id)
        {
            var medicine = GetMedicine(id);

            return medicine.HasWeeklyDosage();
        }
    }
}
