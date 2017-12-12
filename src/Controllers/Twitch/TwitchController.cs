using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Twitch
{
    [Route("twitch")]
    public class TwitchController : Controller
    {
        // Get overall stats for collie's Twitch stuff
        [HttpGet(Name = nameof(GetTwitchAsync))]
        public async Task<IActionResult> GetTwitchAsync()
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
