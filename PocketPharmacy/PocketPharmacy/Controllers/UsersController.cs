using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;

namespace PocketPharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetUsers();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userRepository.GetUser(id);
        }

        // POST: api/users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
