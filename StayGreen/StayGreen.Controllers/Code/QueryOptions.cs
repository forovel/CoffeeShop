using StayGreen.Common.Query;
using StayGreen.Services.Interfaces.Common;
using System.Collections.Generic;

namespace StayGreen.Controllers.Code
{
    public class QueryOptions : IQueryOptions
    {
        public List<SortOption> SortOptions { get; set; }
        public PagingOption PagingOptions { get; set; }
        public List<FilterOption> FilterOptions { get; set; }

        public QueryOptions()
        {
            SortOptions = new List<SortOption>();
            PagingOptions = new PagingOption();
            FilterOptions = new List<FilterOption>();
        }
    }
}
