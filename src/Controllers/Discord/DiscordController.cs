using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Discord
{
    [Route("discord")]
    public class TwitchController : Controller
    {
        // Get overall stats for collie's discord stuff
        [HttpGet(Name = nameof(GetDiscordAsync))]
        public async Task<IActionResult> GetDiscordAsync()
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
