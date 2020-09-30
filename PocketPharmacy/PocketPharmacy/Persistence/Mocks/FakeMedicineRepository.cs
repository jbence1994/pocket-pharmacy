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
                }
            };
        }

        public IEnumerable<Medicine> GetMedicines()
        {
            return _medicines;
        }
    }
}
