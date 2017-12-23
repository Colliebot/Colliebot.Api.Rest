using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Colliebot.Api.Rest.Controllers.Collie
{
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly UserManager _users;

        public UsersController(UserManager users)
        {
            _users = users;
        }

        [HttpGet(Name = nameof(GetUsersAsync))]
        public async Task<IActionResult> GetUsersAsync([FromQuery]EntitySearchOptions options, [FromQuery]PagingOptions paging)
        {
            var users = await _users.GetUsersAsync(x => (options.Id != null || x.Id == options.Id), paging.Offset, paging.Limit);
            if (users.Count() > 0)
            {
                switch (options.Sort)
                {
                    case SortBy.CreatedAt:
                        users = users.OrderBy(x => x.CreatedAt);
                        break;
                    case SortBy.UpdatedAt:
                        users = users.OrderBy(x => x.UpdatedAt);
                        break;
                    case SortBy.Name:
                        users = users.OrderBy(x => x.Name);
                        break;
                    default:
                        users = users.OrderBy(x => x.Id);
                        break;
                }
                return Ok(users);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("count", Name = nameof(GetUsersCountAsync))]
        public async Task<IActionResult> GetUsersCountAsync([FromQuery]EntitySearchOptions options)
        {
            int count = await _users.GetUsersCountAsync(x => (options.Id != null || x.Id == options.Id));
            return Ok(count);
        }
    }
}
