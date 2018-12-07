using StayGreen.Common.Query;
using StayGreen.Services.Interfaces.Common;
using System.Collections.Generic;

namespace StayGreen.Services.Code
{
    public class EmptyQueryOptions : IQueryOptions
    {
        public List<SortOption> SortOptions { get; set; }
        public PagingOption PagingOptions { get; set; }
        public List<FilterOption> FilterOptions { get; set; }
    }
}
