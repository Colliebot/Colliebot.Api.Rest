// From https://github.com/aspnet/Mvc/issues/6215#issuecomment-297976455

using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Colliebot.Api.Rest
{
    public static class ValueProviderFactoriesExtensions
    {
        public static void AddDelimitedValueProviderFactory(
            this IList<IValueProviderFactory> valueProviderFactories,
            params char[] delimiters)
        {
            var queryStringValueProviderFactory = valueProviderFactories
                .OfType<QueryStringValueProviderFactory>()
                .FirstOrDefault();
            if (queryStringValueProviderFactory == null)
            {
                valueProviderFactories.Insert(
                    0,
                    new DelimitedQueryStringValueProviderFactory(delimiters));
            }
            else
            {
                valueProviderFactories.Insert(
                    valueProviderFactories.IndexOf(queryStringValueProviderFactory),
                    new DelimitedQueryStringValueProviderFactory(delimiters));
                valueProviderFactories.Remove(queryStringValueProviderFactory);
            }
        }
    }
}
