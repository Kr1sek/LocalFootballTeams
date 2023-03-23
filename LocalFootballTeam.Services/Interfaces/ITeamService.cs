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
        List<Team> GetAllTeams();
        Team GetTeam(int id);
        List<Team> AddTeam(Team team);
        List<Team> UpdateTeam(Team team, int id);
        List<Team> DeleteTeam(int id);


    }
}
