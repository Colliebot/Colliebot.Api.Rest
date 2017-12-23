using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Colliebot.Api.Rest
{
    public sealed class PagingOptions
    {
        [FromQuery]
        [Range(1, int.MaxValue, ErrorMessage = "Offset must be greater than 0.")]
        public int Offset { get; set; } = Constants.DefaultPageOffset;

        [FromQuery]
        [Range(1, Constants.MaxPageSize, ErrorMessage = "Limit must be greater than 0 and less than 100.")]
        public int Limit { get; set; } = Constants.DefaultPageSize;
    }
}
