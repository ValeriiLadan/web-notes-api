using CDC.WebNotes.Dto;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace CDC.WebNotes.Data.Extensions
{
    public static class PagingExtensions
    {
        public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> query, PagingDto pagingDto)
        {
            return pagingDto is null ?
                               query :
                               query.Skip(pagingDto.Offset).Take(pagingDto.Limit);
        }

        public static IQueryable<TSource> SortBy<TSource, TProperty>(this IQueryable<TSource> query,
                                                                   ListSortDirection sortingOrder,
                                                                   Expression<Func<TSource, TProperty>> propertySelector)
        {
            return sortingOrder == ListSortDirection.Ascending
                ? query.OrderBy(propertySelector)
                : query.OrderByDescending(propertySelector);
        }
    }
}
