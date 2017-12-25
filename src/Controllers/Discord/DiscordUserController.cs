using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Discord
{
    [Route("discord/user")]
    public class DiscordUserController : Controller
    {
        private readonly DiscordUserManager _users;
        private readonly DiscordGuildUserManager _guildUsers;

        public DiscordUserController(DiscordUserManager users, DiscordGuildUserManager guildUsers)
        {
            _users = users;
            _guildUsers = guildUsers;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(ulong id, params DiscordUserInclude[] include)
        {
            var user = await _users.GetAsync(id, include);
            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpGet("{id}/modified")]
        public async Task<IActionResult> GetModifiedAsync(ulong id)
        {
            var updatedAt = await _users.GetLastUpdatedAsync(id);
            if (updatedAt != null)
                return Ok(updatedAt);
            else
                return NotFound();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(ulong id, [FromBody]object changes)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("{id}/guilds")]
        public async Task<IActionResult> GetGuildsAsync(ulong id, [FromQuery]PagingOptions paging)
        {
            var userExists = await _users.ExistsAsync(id);
            if (!userExists)
                return NotFound();

            var guildUsers = await _guildUsers.GetGuildUsersAsync(x => x.UserId == id, paging.Offset, paging.Limit);
            if (guildUsers.Count() > 0)
                return Ok(guildUsers);
            else
                return Ok();
        }

        [HttpGet("{id}/guilds/count")]
        public async Task<IActionResult> GetGuildsCountAsync(ulong id)
        {
            int count = await _guildUsers.CountAsync(x => x.UserId == id);
            return Ok(count);
        }
    }
}
