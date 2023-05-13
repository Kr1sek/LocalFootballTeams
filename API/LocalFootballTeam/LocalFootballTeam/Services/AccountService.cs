using LocalFootballTeam.Models.Dtos;
using LocalFootballTeam.Models.Models;
using LocalFootballTeam.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LocalFootballTeam.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly Migrations.DbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AutheticationSettings _autheticationSettings;

        public AccountService(Migrations.DbContext context, IPasswordHasher<User> passwordHasher, AutheticationSettings autheticationSettings)
        {
            _dbContext = context;
            _passwordHasher = passwordHasher;
            _autheticationSettings = autheticationSettings;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Nationality = dto.Nationality,
                RoleId = dto.RoleId
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _dbContext.Users.Include(u => u.Role).FirstOrDefault(u => u.Email == dto.Email);

            if (user == null)
            {
                return null;
            }

            var resuslt = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (resuslt == PasswordVerificationResult.Failed)
            {
                return null;
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")),
                new Claim("Nationality", user.Nationality)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_autheticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_autheticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_autheticationSettings.JwtIssuer,
                _autheticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
