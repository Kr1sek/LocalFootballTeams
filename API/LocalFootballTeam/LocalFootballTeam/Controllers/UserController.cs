using LocalFootballTeam.Interfaces;
using LocalFootballTeam.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocalFootballTeam.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region GetUserByEmail
        /// <summary>
        /// Showing User by his email
        /// </summary>
        /// <param name="id">Taking Email of User</param>
        /// <returns></returns>
        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var result = await _userService.GetUserByEmail(email);

            if (result == null)
                return NotFound("User doesn't exists");

            return Ok(result);
        }
        #endregion
    }
}
