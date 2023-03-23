using Microsoft.AspNetCore.Mvc;
using LocalFootballTeam.Models.Models;
using LocalFootballTeam.Services.Interfaces;

namespace LocalFootballTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetAllTeams()
        {
            var result = _teamService.GetAllTeams();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var result = _teamService.GetTeam(id);

            if (result == null)
                return NotFound("Team doesn't exists");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Team>>> AddTeam(Team team)
        {
            var result = _teamService.AddTeam(team);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Team>>> UpdateTeam(int id, Team team)
        {
            var result = _teamService.UpdateTeam(team, id);

            if (result == null)
                return NotFound("Team doesn't exists");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var result = _teamService.DeleteTeam(id);

            if (result == null)
                return NotFound("Team doesn't exists");

            return Ok(result);
        }
    }
}
