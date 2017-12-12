using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Twitch
{
    [Route("twitch/channel")]
    public class TwitchChannelController : Controller
    {
        [HttpGet("{id}", Name = nameof(GetChannelAsync))]
        public async Task<IActionResult> GetChannelAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpPatch("{id}", Name = nameof(PatchChannelAsync))]
        public async Task<IActionResult> PatchChannelAsync(ulong id, [FromBody]object changes)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeleteChannelAsync))]
        public async Task<IActionResult> DeleteChannelAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("{id}/users", Name = nameof(GetChannelUsersAsync))]
        public async Task<IActionResult> GetChannelUsersAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }
        
        [HttpGet("{id}/users/count", Name = nameof(GetChannelUserCountAsync))]
        public async Task<IActionResult> GetChannelUserCountAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
