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

        [HttpGet("{id}", Name = nameof(GetUserAsync))]
        public async Task<IActionResult> GetUserAsync(ulong id, params DiscordUserInclude[] include)
        {
            var user = await _users.GetUserAsync(id, include);
            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }

        [HttpPatch("{id}", Name = nameof(PatchUserAsync))]
        public async Task<IActionResult> PatchUserAsync(ulong id, [FromBody]object changes)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeleteUserAsync))]
        public async Task<IActionResult> DeleteUserAsync(ulong id)
        {
            await Task.Delay(0);
            return Ok();
        }

        [HttpGet("{id}/guilds", Name = nameof(GetUserGuildsAsync))]
        public async Task<IActionResult> GetUserGuildsAsync(ulong id, [FromQuery]PagingOptions paging)
        {
            var userExists = await _users.UserExistsAsync(id);
            if (!userExists)
                return NotFound();

            var guildUsers = await _guildUsers.GetGuildUsersAsync(x => x.UserId == id, paging.Offset, paging.Limit);
            if (guildUsers.Count() > 0)
                return Ok(guildUsers);
            else
                return Ok();
        }

        [HttpGet("{id}/guilds/count", Name = nameof(GetUserGuildsCountAsync))]
        public async Task<IActionResult> GetUserGuildsCountAsync(ulong id)
        {
            int count = await _guildUsers.GetGuildUsersCountAsync(x => x.UserId == id);
            return Ok(count);
        }
    }
}
