using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PocketPharmacy.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Medicine> Medicines { get; set; }

        public User()
        {
            Medicines = new Collection<Medicine>();
        }
    }
}
