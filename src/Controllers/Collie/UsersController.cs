﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]EntitySearchOptions options, [FromQuery]PagingOptions paging)
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

        [HttpGet("count")]
        public async Task<IActionResult> GetCountAsync([FromQuery]EntitySearchOptions options)
        {
            int count = await _users.CountAsync(x => (options.Id != null || x.Id == options.Id));
            return Ok(count);
        }
    }
}
