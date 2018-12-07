using StayGreen.Common.Query;
using System.Collections.Generic;

namespace StayGreen.Services.Interfaces.Common
{
    public interface IQueryOptions
    {
        List<SortOption> SortOptions { get; set; }
        PagingOption PagingOptions { get; set; }
        List<FilterOption> FilterOptions { get; set; }
    }
}
