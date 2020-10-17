using System.Collections.Generic;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Core.Repositories
{
    public interface IMedicineRepository
    {
        IEnumerable<Medicine> GetMedicines(int userId);
        Medicine GetMedicine(int userId, int medicineId);
        void AddMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
        void DeleteMedicine(int userId, int medicineId);
        double GetWeeklyDosage(int userId, int medicineId);
        bool IsExpiredMedicine(int userId, int medicineId);
        bool HasWeeklyDosage(int userId, int medicineId);
    }
}
