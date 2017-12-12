using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers
{
    public class RootController : Controller
    {
        // Get general stats for all of collie's stuff
        [HttpGet(Name = nameof(GetRootAsync))]
        public async Task<IActionResult> GetRootAsync()
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
