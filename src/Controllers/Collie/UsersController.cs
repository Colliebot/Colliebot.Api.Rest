using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Collie
{
    [Route("users")]
    public class UsersController : Controller
    {
        [HttpGet(Name = nameof(GetUsersAsync))]
        public async Task<IActionResult> GetUsersAsync(string discrim = null, DateTime? createdAt = null)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("count", Name = nameof(GetUsersCountAsync))]
        public async Task<IActionResult> GetUsersCountAsync(DateTime? createdAt = null)
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
