using System.Collections.Generic;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Core
{
    public interface IMedicineRepository
    {
        IEnumerable<Medicine> GetMedicines();
    }
}
