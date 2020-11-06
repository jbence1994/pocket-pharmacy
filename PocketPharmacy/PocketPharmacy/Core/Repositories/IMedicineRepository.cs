using System.Collections.Generic;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Core.Repositories
{
    public interface IMedicineRepository
    {
        IEnumerable<Medicine> GetMedicines(int userId);
        Medicine GetMedicine(int userId, int medicineId);
        Medicine GetMedicine(int id);
        void AddMedicine(Medicine medicine);
        void DeleteMedicine(int id);
        double GetWeeklyDosage(int id);
        bool IsExpiredMedicine(int id);
        bool HasWeeklyDosage(int id);
    }
}
