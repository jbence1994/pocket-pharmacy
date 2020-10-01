using System.Collections.Generic;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Core.Repositories
{
    public interface IMedicineRepository
    {
        IEnumerable<Medicine> GetMedicines();
        Medicine GetMedicine(int id);
    }
}
