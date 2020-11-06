using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PocketPharmacy.Controllers.Resources.User;
using PocketPharmacy.Core;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // POST: api/users/register
        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterOrLoginUserResource registerOrLoginUser)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = _mapper.Map<RegisterOrLoginUserResource, User>(registerOrLoginUser);
                _userRepository.AddUser(user);

                _unitOfWork.Complete();

                user = _userRepository.GetUser(user.Id);
                var registeredUser = _mapper.Map<User, RegisteredUserResource>(user);

                return Ok(registeredUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/users/login
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] RegisterOrLoginUserResource registerOrLoginUser)
        {
            try
            {
                var token =
                    _userRepository.Authenticate(registerOrLoginUser.Username, registerOrLoginUser.Password);

                var user = _userRepository.GetUser(registerOrLoginUser.Username);

                var authenticatedUser = _mapper.Map<User, AuthenticatedUserResource>(user);
                authenticatedUser.Token = token;

                return Ok(authenticatedUser);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
