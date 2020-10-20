using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PocketPharmacy.Core;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;
using PocketPharmacy.Resources;

namespace PocketPharmacy.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/users
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userRepository.GetUsers();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<GetUserResource>>(users);

            return Ok(userResources);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _userRepository.GetUser(id);
                var userResource = _mapper.Map<User, GetUserResource>(user);

                return Ok(userResource);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/users
        [HttpPost]
        public IActionResult Post([FromBody] SaveUserResource userResource)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = _mapper.Map<SaveUserResource, User>(userResource);
                _userRepository.AddUser(user);
                
                _unitOfWork.Complete();

                user = _userRepository.GetUser(user.Id);
                var result = _mapper.Map<User, GetUserResource>(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
