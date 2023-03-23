using LocalFootballTeam.Models.Models;
using LocalFootballTeam.Services.Interfaces;

namespace LocalFootballTeam.Services.Services
{
    public class TeamService : ITeamService
    {
        private static List<Team> teams = new List<Team>
            {

                new Team
                {
                    Id = 1,
                    Name = "LKS Sanoczanka",
                    Addres = "Święte 130",
                    StartYear = "1947",
                    Logo="sanoczanka.png"
                },
                new Team
                {
                    Id = 2,
                    Name = "Dąb Dobkowice",
                    Addres = "Dabkowice 208",
                    StartYear = "1952",
                    Logo="dabkowice.png"
                }
            };


        public List<Team> GetAllTeams()
        {
            var result = teams;

            return result;
        }

        public Team GetTeam(int id)
        {
            var result = teams.Find(x => x.Id == id);

            if (result == null)
                return null;

            return result;
        }
        public List<Team> AddTeam(Team team)
        {
            teams.Add(team); 
            
            return teams;
        }

        public List<Team> UpdateTeam(Team team, int id)
        {
            var result = teams.Find(x => x.Id == id);

            if (result == null)
                return null;

            result.Name = team.Name;
            result.Addres = team.Addres;
            result.StartYear = team.StartYear;
            result.Logo = team.Logo;

            return teams;
        }

        public List<Team> DeleteTeam(int id)
        {
            var result = teams.Find(x => x.Id == id);

            if (result == null)
                return null;

            teams.Remove(result); 
            
            return teams;
        }
    }
}
