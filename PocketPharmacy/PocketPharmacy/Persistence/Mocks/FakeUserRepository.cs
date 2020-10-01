using System.Collections.Generic;
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
            return _users.Find(user => user.Id == id);
        }
    }
}
