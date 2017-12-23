using Microsoft.AspNetCore.Mvc;
using System;

namespace Colliebot.Api.Rest
{
    public class EntitySearchOptions
    {
        [FromQuery]
        public ulong? Id { get; set; }
        [FromQuery]
        public DateTime? CreatedAt { get; set; }
        [FromQuery]
        public DateTime? LinkedAt { get; set; }
        [FromQuery]
        public Direction Order { get; set; } = Direction.Ascending;
        [FromQuery]
        public SortBy Sort { get; set; } = SortBy.Id;
    }
}
