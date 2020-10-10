using System.Collections.Generic;

namespace PocketPharmacy.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IList<Stock> Stocks { get; set; }

        public User()
        {
            Stocks = new List<Stock>();
        }
    }
}
