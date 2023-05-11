using LocalFootballTeam.Migrations;
using LocalFootballTeam.Models.Dtos;
using LocalFootballTeam.Models.Models;
using LocalFootballTeam.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFootballTeam.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly DbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(DbContext context, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = context;
            _passwordHasher = passwordHasher;
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
    }
}
