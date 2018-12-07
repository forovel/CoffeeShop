using Microsoft.AspNetCore.Mvc.ModelBinding;
using StayGreen.Common.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayGreen.Controllers.Code
{
    public class QueryOptionsModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var result = new QueryOptions();

            // Try to fetch the value of the argument by name
            var paging = bindingContext.ValueProvider.GetValue("paging");
            if (paging.FirstValue == null)
            {
                result.PagingOptions = new PagingOption();
            }

            var filter = bindingContext.ValueProvider.GetValue("filter");
            if (!string.IsNullOrWhiteSpace(filter.FirstValue))
            {
                result.FilterOptions = ParseFilterOptions(filter.FirstValue);
            }

            var ordering = bindingContext.ValueProvider.GetValue("orderby");
            if (ordering.FirstValue == null)
            {
                result.SortOptions = new List<SortOption>();
            }

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }

        private List<FilterOption> ParseFilterOptions(string filterString)
        {
            var result = new List<FilterOption>();

            if (string.IsNullOrWhiteSpace(filterString))
            {
                return result;
            }

            var chunks = filterString.Split(";", StringSplitOptions.RemoveEmptyEntries);
            if (chunks.Length == 0)
            {
                return result;
            }

            foreach (var chunk in chunks)
            {
                var nameValueArray = chunk.Split(":", StringSplitOptions.RemoveEmptyEntries);
                result.Add(new FilterOption { Name = nameValueArray[0], Operator = ":", Value = nameValueArray[1] });
            }

            return result;
        }
    }
}
