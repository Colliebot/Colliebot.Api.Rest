using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Discord
{
    [Route("discord/guild")]
    public class DiscordGuildController : Controller
    {
        private readonly DiscordGuildManager _guilds;
        private readonly DiscordGuildUserManager _guildUsers;

        public DiscordGuildController(DiscordGuildManager guilds, DiscordGuildUserManager guildUsers)
        {
            _guilds = guilds;
            _guildUsers = guildUsers;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(ulong id, params DiscordGuildInclude[] include)
        {
            var guild = await _guilds.GetAsync(id, include);
            if (guild != null)
                return Ok(guild);
            else
                return NotFound();
        }

        [HttpGet("{id}/modified")]
        public async Task<IActionResult> GetModifiedAsync(ulong id)
        {
            var updatedAt = await _guilds.GetLastUpdatedAsync(id);
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

        [HttpGet("{id}/users")]
        public async Task<IActionResult> GetUsersAsync(ulong id, [FromQuery]PagingOptions paging)
        {
            var guildExists = await _guilds.ExistsAsync(id);
            if (!guildExists)
                return NotFound();

            var guildUsers = await _guildUsers.GetGuildUsersAsync(x => x.GuildId == id, paging.Offset, paging.Limit);
            if (guildUsers.Count() > 0)
                return Ok(guildUsers);
            else
                return Ok();
        }
        
        [HttpGet("{id}/users/count")]
        public async Task<IActionResult> GetUsersCountAsync(ulong id)
        {
            int count = await _guildUsers.CountAsync(x => x.GuildId == id);
            return Ok(count);
        }
    }
}
