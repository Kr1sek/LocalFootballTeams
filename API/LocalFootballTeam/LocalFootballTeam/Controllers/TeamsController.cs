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

        #region GetAllTeams
        /// <summary>
        /// Getting List of all existing Teams
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetAllTeams()
        {
            var result = await _teamService.GetAllTeams();

            return Ok(result);
        }
        #endregion

        #region GetTeam
        /// <summary>
        /// Showing Team by his id
        /// </summary>
        /// <param name="id">Taking Id of Team</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var result = await _teamService.GetTeam(id);

            if (result == null)
                return NotFound("Team doesn't exists");

            return Ok(result);
        }
        #endregion

        #region AddTeam
        /// <summary>
        /// Adding Team into Data Base
        /// </summary>
        /// <param name="team">Taking model of Team</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<Team>>> AddTeam(Team team)
        {
            var result = await _teamService.AddTeam(team);

            return Ok(result);
        }
        #endregion

        #region UpdateTeam
        /// <summary>
        /// Finding a Team by his id and update him 
        /// </summary>
        /// <param name="id">Taking id of Team to find</param>
        /// <param name="team">Taking model team to update finded team</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Team>>> UpdateTeam(int id, Team team)
        {
            var result = await _teamService.UpdateTeam(team, id);

            if (result == null)
                return NotFound("Team doesn't exists");

            return Ok(result);
        }
        #endregion

        #region DeleteTeam
        /// <summary>
        /// Removing a Team
        /// </summary>
        /// <param name="id">Taking Id of Team to find</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var result = await _teamService.DeleteTeam(id);

            if (result == null)
                return NotFound("Team doesn't exists");

            return Ok(result);
        }
        #endregion
    }
}
