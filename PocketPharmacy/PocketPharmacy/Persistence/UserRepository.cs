using System;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PocketPharmacy.Core.Models;
using PocketPharmacy.Core.Repositories;

namespace PocketPharmacy.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public User GetUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                throw new Exception("Nem létező felhasználó.");

            return user;
        }

        public User GetUser(string username)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username);

            if (user == null)
                throw new Exception("Nem létező felhasználónév.");

            return user;
        }

        public void AddUser(User user)
        {
            if (_context.Users.ToList().Exists(u => u.Username == user.Username))
                throw new Exception("Létező felhasználónév.");

            _context.Users.Add(user);
        }

        public string Authenticate(string username, string password)
        {
            if (!_context.Users.ToList().Any(u => u.Username == username &&
                                                  u.Password == password))
                throw new Exception("Hibás felhasználónév vagy jelszó!");

            var credentials = new SigningCredentials(
                key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"])),
                algorithm: SecurityAlgorithms.HmacSha256Signature
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new[] {new Claim(ClaimTypes.Name, username)},
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
