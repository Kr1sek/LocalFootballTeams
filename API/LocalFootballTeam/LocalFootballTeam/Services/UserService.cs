using LocalFootballTeam.Interfaces;
using LocalFootballTeam.Migrations;
using LocalFootballTeam.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalFootballTeam.Services
{
    public class UserService : IUserService
    {
        private readonly Migrations.DbContext _context;

        public UserService(Migrations.DbContext context)
        {
            _context = context;
        }


        #region GetTeam
        public async Task<User> GetUserByEmail(string email)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));

            if (result == null)
                return null;

            return result;
        }
        #endregion
    }
}
