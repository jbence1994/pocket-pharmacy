using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Core.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);
        User GetUser(string username);
        void AddUser(User user);
        string Authenticate(string username, string password);
    }
}
