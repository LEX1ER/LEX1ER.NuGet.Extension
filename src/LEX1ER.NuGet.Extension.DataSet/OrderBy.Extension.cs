using LEX1ER.NuGet.Extension.DataSet.Interfaces;
using System.Linq.Dynamic.Core;

namespace LEX1ER.NuGet.Extension.DataSet
{
    public static partial class Extension
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, IOrderBy orderBy)
        {
            var order = new List<string>();
            for (int i = 0; i < orderBy.Sort.Length; i++)
            {
                var sort = orderBy.Sort[i];
                var sortBy = orderBy.SortBy[i];
                var sortType = sort ? "DESC" : "ASC";
                order.Add($"{sortBy} {sortType}");
            }
            if (order.Count() == 0) return source;
            var orderArray = string.Join(",", order);
            var entities = source.OrderBy(orderArray);
            entities ??= default!;
            return entities;
        }
    }
}
