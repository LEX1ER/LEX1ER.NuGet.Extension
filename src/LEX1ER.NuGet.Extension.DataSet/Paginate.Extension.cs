using LEX1ER.NuGet.Extension.DataSet.Interfaces;

namespace LEX1ER.NuGet.Extension.DataSet
{
    public static partial class Extension
    {
        internal static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> entities, IPaginate paginate)
        {
            var page = paginate.Page;
            var itemPerPage = paginate.ItemsPerPage;

            var take = itemPerPage;
            var skip = (page - 1) * take;
            var data = entities;

            if (take > 0)
            {
                data = data
                    .Skip(skip)
                    .Take(take);
            }
            return data;
        }
    }
}
