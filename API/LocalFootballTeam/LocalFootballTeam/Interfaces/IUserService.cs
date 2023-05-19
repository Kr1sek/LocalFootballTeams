using LocalFootballTeam.Models.Models;

namespace LocalFootballTeam.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByEmail(string email);
    }
}
