using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Discord
{
    [Route("discord/guild")]
    public class TwitchGuildController : Controller
    {
        [HttpGet("{id}", Name = nameof(GetGuildAsync))]
        public async Task<IActionResult> GetGuildAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpPatch("{id}", Name = nameof(PatchGuildAsync))]
        public async Task<IActionResult> PatchGuildAsync(ulong id, [FromBody]object changes)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeleteGuildAsync))]
        public async Task<IActionResult> DeleteGuildAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("{id}/users", Name = nameof(GetGuildUsersAsync))]
        public async Task<IActionResult> GetGuildUsersAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }
        
        [HttpGet("{id}/users/count", Name = nameof(GetGuildUserCountAsync))]
        public async Task<IActionResult> GetGuildUserCountAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
