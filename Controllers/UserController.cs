using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ModularMonolith_DecoupledBoundaries.Services;

namespace ModularMonolith_DecoupledBoundaries.Controllers
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
