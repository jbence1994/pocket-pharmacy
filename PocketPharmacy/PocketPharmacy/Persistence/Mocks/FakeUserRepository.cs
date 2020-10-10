using System;
using System.Collections.Generic;
using System.Linq;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;

namespace PocketPharmacy.Persistence.Mocks
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public FakeUserRepository()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "jbence",
                    Password = "12345"
                },
                new User
                {
                    Id = 2,
                    Username = "lnoemi",
                    Password = "12345"
                },
                new User
                {
                    Id = 3,
                    Username = "bmartin",
                    Password = "12345"
                }
            };
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public User GetUser(int id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                throw new Exception("Nem létező felhasználó.");

            return user;
        }

        public IEnumerable<Stock> GetStocks(int userId)
        {
            var user = GetUser(userId);
            return user.Stocks;
        }
    }
}
