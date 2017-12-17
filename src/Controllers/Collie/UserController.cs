using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Collie
{
    [Route("user")]
    public class UserController : Controller
    {
        [HttpGet("{id}", Name = nameof(GetUserAsync))]
        public async Task<IActionResult> GetUserAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}