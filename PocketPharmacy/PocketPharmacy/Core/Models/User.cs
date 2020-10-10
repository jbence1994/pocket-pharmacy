using System.Collections.Generic;

namespace PocketPharmacy.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IList<Medicine> Medicines { get; set; }

        public User()
        {
            Medicines = new List<Medicine>();
        }
    }
}
