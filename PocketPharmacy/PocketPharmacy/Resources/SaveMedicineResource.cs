using System;

namespace PocketPharmacy.Resources
{
    public class SaveMedicineResource
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool NeedPrescription { get; set; }
        public DosageResource Dosage { get; set; }
        public int Quantity { get; set; }
    }
}
