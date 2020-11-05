using PocketPharmacy.Core.Models;

namespace PocketPharmacy.Core.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);
        void AddUser(User user);
    }
}
