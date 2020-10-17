using System.Collections.Generic;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Core.Repositories
{
    public interface IMedicineRepository
    {
        IEnumerable<Medicine> GetMedicines(int userId);
        Medicine GetMedicine(int userId, int medicineId);
        void AddMedicine(Medicine medicine);
        void DeleteMedicine(int userId, int medicineId);
    }
}
