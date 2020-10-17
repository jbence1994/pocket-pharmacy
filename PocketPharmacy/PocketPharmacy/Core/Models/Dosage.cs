namespace PocketPharmacy.Core.Models
{
    public class Dosage
    {
        public int Id { get; set; }
        public Medicine Medicine { get; set; }
        public int MedicineId { get; set; }
        public int PerDays { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
    }
}
