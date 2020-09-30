using System;
using System.Collections.Generic;
using PocketPharmacy.Core;
using PocketPharmacy.Core.Models;

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
            return _medicines.Find(medicine => medicine.Id == id);
        }
    }
}
