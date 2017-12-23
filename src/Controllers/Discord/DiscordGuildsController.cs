using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Discord
{
    [Route("discord/guilds")]
    public class DiscordGuildsController : Controller
    {
        private readonly DiscordGuildManager _guilds;

        public DiscordGuildsController(DiscordGuildManager guilds)
        {
            _guilds = guilds;
        }

        [HttpGet(Name = nameof(GetGuildsAsync))]
        public async Task<IActionResult> GetGuildsAsync([FromQuery]EntitySearchOptions options, [FromQuery]PagingOptions paging)
        {
            var guilds = await _guilds.GetGuildsAsync(x => (options.Id != null || x.Id == options.Id), paging.Offset, paging.Limit);
            if (guilds.Count() > 0)
            {
                switch (options.Sort)
                {
                    case SortBy.CreatedAt:
                        guilds = guilds.OrderBy(x => x.CreatedAt);
                        break;
                    case SortBy.UpdatedAt:
                        guilds = guilds.OrderBy(x => x.UpdatedAt);
                        break;
                    case SortBy.Name:
                        guilds = guilds.OrderBy(x => x.Name);
                        break;
                    default:
                        guilds = guilds.OrderBy(x => x.Id);
                        break;
                }
                return Ok(guilds);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("count", Name = nameof(GetGuildsCountAsync))]
        public async Task<IActionResult> GetGuildsCountAsync([FromQuery]EntitySearchOptions options)
        {
            int count = await _guilds.GetGuildsCountAsync(x => (options.Id != null || x.Id == options.Id));
            return Ok(count);
        }
    }
}
