using System;
using System.Collections.Generic;
using System.Linq;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;

namespace PocketPharmacy.Persistence.Mocks
{
    public class FakeMedicineRepository : IMedicineRepository
    {
        private readonly List<Medicine> _medicines;

        public FakeMedicineRepository()
        {
            _medicines = new List<Medicine>
            {
                new Medicine
                {
                    Id = 1,
                    Name = "Magic Pills For Everything",
                    Description = "...",
                    Amount = 30,
                    Unit = "pills",
                    ExpirationDate = new DateTime(2020, 09, 01),
                    NeedPrescription = true,
                    Dosage = new Dosage
                    {
                        Id = 1,
                        PerDays = 1,
                        Amount = 2,
                        Unit = "pills"
                    }
                },
                new Medicine
                {
                    Id = 2,
                    Name = "Magic Potion For Everything",
                    Description = "...",
                    Amount = 300,
                    Unit = "mg",
                    ExpirationDate = new DateTime(2021, 01, 01),
                    NeedPrescription = false,
                    Dosage = new Dosage
                    {
                        Id = 2,
                        PerDays = 2,
                        Amount = 3,
                        Unit = "mg"
                    }
                }
            };
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            return _medicines;
        }

        public Medicine GetMedicine(int id)
        {
            var medicine = _medicines.SingleOrDefault(m => m.Id == id);

            if (medicine == null)
                throw new Exception("Nem létező gyógyszer.");

            return medicine;
        }

        public Dosage GetDosage(int medicineId)
        {
            var medicine = GetMedicine(medicineId);
            return medicine.Dosage;
        }
    }
}
