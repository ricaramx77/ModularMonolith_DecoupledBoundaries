using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ModularMonolith_DecoupledBoundaries.UserModule
{
    [ApiController]
    [Route("api/v{version:apiVersion}/users")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class UserController : ControllerBase
    {
        private readonly UserService _users;

        public UserController(UserService users)
        {
            _users = users;
        }

        [HttpPost("deactivate")]
        public IActionResult DeactivateUser(int userId)
        {
            _users.Deactivate(userId);
            return Ok("User deactivated.");
        }
    }
}
