using System.Collections.Generic;
using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        IEnumerable<Stock> GetStocks(int userId);
    }
}
