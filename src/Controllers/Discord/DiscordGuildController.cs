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

        [HttpGet("{id}", Name = nameof(GetGuildAsync))]
        public async Task<IActionResult> GetGuildAsync(ulong id, params DiscordGuildInclude[] include)
        {
            var guild = await _guilds.GetGuildAsync(id, include);
            if (guild != null)
                return Ok(guild);
            else
                return NotFound();
        }

        [HttpPatch("{id}", Name = nameof(PatchGuildAsync))]
        public async Task<IActionResult> PatchGuildAsync(ulong id, [FromBody]object changes)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeleteGuildAsync))]
        public async Task<IActionResult> DeleteGuildAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("{id}/users", Name = nameof(GetGuildUsersAsync))]
        public async Task<IActionResult> GetGuildUsersAsync(ulong id, [FromQuery]PagingOptions paging)
        {
            var guildExists = await _guilds.GuildExistsAsync(id);
            if (!guildExists)
                return NotFound();

            var guildUsers = await _guildUsers.GetGuildUsersAsync(x => x.GuildId == id, paging.Offset, paging.Limit);
            if (guildUsers.Count() > 0)
                return Ok(guildUsers);
            else
                return Ok();
        }
        
        [HttpGet("{id}/users/count", Name = nameof(GetGuildUserCountAsync))]
        public async Task<IActionResult> GetGuildUserCountAsync(ulong id)
        {
            int count = await _guildUsers.GetGuildUsersCountAsync(x => x.GuildId == id);
            return Ok(count);
        }
    }
}
