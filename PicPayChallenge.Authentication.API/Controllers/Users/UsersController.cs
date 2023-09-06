using Microsoft.AspNetCore.Mvc;
using PicPayChallenge.Authentication.Application.Users.Services.Interfaces;
using PicPayChallenge.Authentication.DataTransfer.Users.Requests;
using PicPayChallenge.Authentication.DataTransfer.Users.Responses;

namespace PicPayChallenge.Authentication.API.Controllers.Users
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersAppService usersAppService;

        public UsersController(IUsersAppService usersAppService)
        {
            this.usersAppService = usersAppService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] UserRegisterRequest request)
        {
            usersAppService.RegisterUser(request);
            return Ok();
        }

        [HttpPost("auth")]
        public ActionResult<UserAuthResponse> AuthUser([FromBody] UserAuthRequest request)
        {
            var response = usersAppService.AuthUser(request);
            return Ok(response);
        }
    }
}
