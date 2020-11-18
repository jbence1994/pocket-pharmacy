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
    [EnableCors("PocketPharmacyCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthenticationController(IUserRepository accountRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // POST: api/authentication/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterOrAuthenticateUserResource registerOrAuthenticateUser)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = _mapper.Map<RegisterOrAuthenticateUserResource, User>(registerOrAuthenticateUser);
                _accountRepository.AddUser(user);

                _unitOfWork.Complete();

                user = _accountRepository.GetUser(user.Id);
                var registeredUser = _mapper.Map<User, RegisteredUserResource>(user);

                return Ok(registeredUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/authentication/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] RegisterOrAuthenticateUserResource registerOrAuthenticateUser)
        {
            try
            {
                var username = registerOrAuthenticateUser.Username;
                var password = registerOrAuthenticateUser.Password;

                var token = _accountRepository.Authenticate(username, password);

                var user = _accountRepository.GetUser(username);
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
