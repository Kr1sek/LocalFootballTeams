using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LocalFootballTeam.Models.Models;
using System.Runtime.CompilerServices;

namespace LocalFootballTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
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

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetAllTeams()
        {
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var result = teams.Find(x => x.Id == id);

            if (result == null)
                return NotFound("Team doesn't exists");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Team>>> AddTeam(Team team)
        {
            teams.Add(team);
            return Ok(teams);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Team>>> UpdateTeam(int id, Team team)
        {
            var result = teams.Find(x => x.Id == id);

            if (result == null)
                return NotFound("Team doesn't exists");

            result.Name = team.Name;
            result.Addres = team.Addres;
            result.StartYear = team.StartYear;
            result.Logo = team.Logo;

            return Ok(teams);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var result = teams.Find(x => x.Id == id);

            if (result == null)
                return NotFound("Team doesn't exists");

            teams.Remove(result);

            return Ok(result);
        }
    }
}
