using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Twitch
{
    [Route("twitch/user")]
    public class TwitchUserController : Controller
    {
        [HttpGet("{id}", Name = nameof(GetUserAsync))]
        public async Task<IActionResult> GetUserAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpPatch("{id}", Name = nameof(PatchUserAsync))]
        public async Task<IActionResult> PatchUserAsync(ulong id, [FromBody]object changes)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeleteUserAsync))]
        public async Task<IActionResult> DeleteUserAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("{id}/users", Name = nameof(GetUserGuildsAsync))]
        public async Task<IActionResult> GetUserGuildsAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("{id}/users/count", Name = nameof(GetUserGuildsCountAsync))]
        public async Task<IActionResult> GetUserGuildsCountAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
