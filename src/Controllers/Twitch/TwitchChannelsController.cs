using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Twitch
{
    [Route("twitch/channels")]
    public class TwitchChannelsController : Controller
    {
        [HttpGet(Name = nameof(GetChannelsAsync))]
        public async Task<IActionResult> GetChannelsAsync(DateTime? createdAt = null, DateTime? linkedAt = null)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("count", Name = nameof(GetChannelsCountAsync))]
        public async Task<IActionResult> GetChannelsCountAsync(DateTime? createdAt = null, DateTime? linkedAt = null)
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
