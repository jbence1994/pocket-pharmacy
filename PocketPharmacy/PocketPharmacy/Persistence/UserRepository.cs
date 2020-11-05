using System;
using System.Linq;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;

namespace PocketPharmacy.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                throw new Exception("Nem létező felhasználó.");

            return user;
        }

        public void AddUser(User user)
        {
            if (_context.Users.ToList().Exists(u => u.Username == user.Username))
                throw new Exception("Létező felhasználónév.");

            _context.Users.Add(user);
        }
    }
}
