using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Discord
{
    [Route("discord/guilds")]
    public class TwitchGuildsController : Controller
    {
        [HttpGet(Name = nameof(GetGuildsAsync))]
        public async Task<IActionResult> GetGuildsAsync(DateTime? createdAt = null, DateTime? linkedAt = null)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("count", Name = nameof(GetGuildsCountAsync))]
        public async Task<IActionResult> GetGuildsCountAsync(DateTime? createdAt = null, DateTime? linkedAt = null)
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
