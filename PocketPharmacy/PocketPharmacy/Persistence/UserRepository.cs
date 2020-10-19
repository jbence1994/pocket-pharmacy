using System;
using System.Collections.Generic;
using System.Linq;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;

namespace PocketPharmacy.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly PocketPharmacyDbContext _context;

        public UserRepository(PocketPharmacyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
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
            _context.Users.Add(user);
        }
    }
}
