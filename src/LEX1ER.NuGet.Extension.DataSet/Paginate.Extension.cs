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

            var data = entities
                .Take(take)
                .Skip(skip);
            return data;
        }
    }
}
