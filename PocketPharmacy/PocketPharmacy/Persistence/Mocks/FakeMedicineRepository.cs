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
                    DosageId = 1,
                    Dosage = new Dosage
                    {
                        Id = 1,
                        PerDays = 1,
                        Amount = 2,
                        Unit = "pills"
                    },
                    UserId = 1,
                    User = new User
                    {
                        Id = 1,
                        Username = "jbence",
                        Password = "12345"
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
                    DosageId = 2,
                    Dosage = new Dosage
                    {
                        Id = 2,
                        PerDays = 2,
                        Amount = 3,
                        Unit = "mg"
                    },
                    UserId = 1,
                    User = new User
                    {
                        Id = 1,
                        Username = "jbence",
                        Password = "12345"
                    }
                }
            };
        }

        public IEnumerable<Medicine> GetMedicines(int userId)
        {
            return _medicines.Where(m => m.UserId == userId);
        }

        public Medicine GetMedicine(int userId, int medicineId)
        {
            var medicine = GetMedicines(userId)
                .SingleOrDefault(m => m.Id == medicineId);

            if (medicine == null)
                throw new Exception("Nem létező gyógyszer.");

            return medicine;
        }
    }
}
