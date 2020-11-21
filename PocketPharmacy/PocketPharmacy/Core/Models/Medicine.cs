using System;

namespace PocketPharmacy.Core.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool NeedPrescription { get; set; }
        public int Quantity { get; set; }
        public Dosage Dosage { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        public double GetWeeklyDosage()
        {
            const int numberOfDays = 7;

            return Dosage.Amount * Dosage.PerDay * numberOfDays;
        }

        public bool IsExpired()
        {
            return DateTime.Now > ExpirationDate;
        }

        public bool HasWeeklyDosage()
        {
            var totalAmount = Amount * Quantity;

            var weeklyDosage = GetWeeklyDosage();

            return totalAmount >= weeklyDosage;
        }
    }
}
