using LocalFootballTeam.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFootballTeam.Services.Interfaces
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllTeams();
        Task<Team> GetTeam(int id);
        Task<List<Team>> AddTeam(Team team);
        Task<List<Team>> UpdateTeam(Team team, int id);
        Task<List<Team>> DeleteTeam(int id);

    }
}
