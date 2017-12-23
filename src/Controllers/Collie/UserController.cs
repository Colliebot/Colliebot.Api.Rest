using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Collie
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly UserManager _users;

        public UserController(UserManager users)
        {
            _users = users;
        }

        [HttpGet("{id}", Name = nameof(GetUserAsync))]
        public async Task<IActionResult> GetUserAsync(ulong id, params UserInclude[] include)
        {
            var user = await _users.GetUserAsync(id, include);
            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }
    }
}