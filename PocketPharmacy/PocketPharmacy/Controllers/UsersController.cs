using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PocketPharmacy.Controllers.Resources;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;

namespace PocketPharmacy.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        // GET: api/users
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetUsers();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

            return Ok(userResources);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _userRepository.GetUser(id);
                var userResource = _mapper.Map<User, UserResource>(user);

                return Ok(userResource);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/users
        [HttpPost]
        public IActionResult Post([FromBody] UserResource userResource)
        {
            try
            {
                var user = _mapper.Map<UserResource, User>(userResource);
                _userRepository.AddUser(user);

                return Ok(userResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
