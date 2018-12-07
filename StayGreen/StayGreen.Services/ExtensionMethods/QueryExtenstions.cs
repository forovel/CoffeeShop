using AutoMapper;
using StayGreen.Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using Z.Expressions;

namespace StayGreen.Services.ExtensionMethods
{
    public static class QueryExtenstions
    {
        public static PaginatedList<TDto> ApplyPagination<T, TDto>(this IQueryable<T> list, PagingOption pagingOption)
        {
            var items = list.Skip(pagingOption.PageIndex).Take(pagingOption.PageSize);

            var dtoItems = Mapper.Map<IList<TDto>>(items);

            var count = list.Count();
            var result = new PaginatedList<TDto>(dtoItems, count, pagingOption.PageIndex, pagingOption.PageSize);

            return result;
        }

        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> list, IList<SortOption> sortOptions)
        {
            IQueryable<T> result = default(IQueryable<T>);

            foreach (var sortOption in sortOptions)
            {
                var cleanField = sortOption.SortField.Replace("-", string.Empty);

                result = sortOption.SortField.StartsWith("-", StringComparison.Ordinal)
                    ? list.OrderByDescendingDynamic(x => $"x.{cleanField}")
                    : list.OrderByDynamic(x => $"x.{cleanField}");
            }

            return result ?? list;
        }
    }
}
