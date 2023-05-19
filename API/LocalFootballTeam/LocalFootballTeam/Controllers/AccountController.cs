using LocalFootballTeam.Interfaces;
using LocalFootballTeam.Models.Dtos;
using LocalFootballTeam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocalFootballTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;


        public AccountController(IAccountService accountService, IUserService userService) 
        {
            _accountService = accountService;
            _userService = userService;
        }

        #region RegisterUser()
        /// <summary>
        /// Creating new User
        /// </summary>
        /// <param name="dto">Taking Dto paramteres (Email and Password) </param>
        /// <returns></returns>
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);

            return Ok();
        }
        #endregion

        #region Login()
        /// <summary>
        /// Login User and generate a Jwt Token 
        /// </summary>
        /// <param name="dto">Taking Dto parameters (Email and Password) </param>
        /// <returns></returns>
        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            var user = _userService.GetUserByEmail(dto.Email);

            return Ok(new { token, user });
        }
        #endregion

    }
}
