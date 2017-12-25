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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(ulong id, params UserInclude[] include)
        {
            var user = await _users.GetAsync(id, include);
            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpGet("{id}/modified")]
        public async Task<IActionResult> GetModifiedAsync(ulong id)
        {
            var updatedAt = await _users.GetLastUpdatedAsync(id);
            if (updatedAt != null)
                return Ok(updatedAt);
            else
                return NotFound();
        }
    }
}