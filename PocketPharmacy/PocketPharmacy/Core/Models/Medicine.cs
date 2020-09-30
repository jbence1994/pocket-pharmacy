using System;

namespace PocketPharmacy.Core.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool NeedPrescription { get; set; }
        public Dosage Dosage { get; set; }

        public double GetWeeklyDosage()
        {
            return 0;
        }

        public bool IsExpired()
        {
            return false;
        }

        public bool HasWeeklyDosage()
        {
            return false;
        }
    }
}
