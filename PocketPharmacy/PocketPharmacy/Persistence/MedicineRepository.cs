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
            _context.SaveChanges();
        }

        public void UpdateMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedicine(int userId, int medicineId)
        {
            var medicine = GetMedicine(userId, medicineId);

            if (medicine == null)
                throw new Exception("Nem létező gyógyszer.");

            _context.Medicines.Remove(medicine);
            _context.SaveChanges();
        }

        public double GetWeeklyDosage(int userId, int medicineId)
        {
            return GetMedicine(userId, medicineId).GetWeeklyDosage();
        }

        public bool IsExpiredMedicine(int userId, int medicineId)
        {
            return GetMedicine(userId, medicineId).IsExpired();
        }

        public bool HasWeeklyDosage(int userId, int medicineId)
        {
            return GetMedicine(userId, medicineId).HasWeeklyDosage();
        }
    }
}
