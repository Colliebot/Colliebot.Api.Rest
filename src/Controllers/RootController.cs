using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers
{
    public class RootController : Controller
    {
        // Get information about the currently authenticated user
        [HttpGet]
        public async Task<IActionResult> GetRootAsync()
        {
            await Task.Delay(0);
            return Ok();
        }
    }
}
