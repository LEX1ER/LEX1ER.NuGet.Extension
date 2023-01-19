using LEX1ER.NuGet.Extension.DataSet.Interfaces;
using System.Collections;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace LEX1ER.NuGet.Extension.DataSet
{
    public class DataTable<TEntity> where TEntity : class
    {
        private IQueryable<TEntity> Entities { get; set; } = default!;
        private IRequest Request { get; set; } = default!;
        public IQueryable<TEntity> Data { get; set; } = default!;
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public DataTable(IQueryable<TEntity> entities)
        {
            Request ??= new Request();
            Entities = entities;
        }
        public DataTable(IQueryable<TEntity> entities, IRequest request)
        {
            Entities = entities;
            Request = request;
        }
        public DataTable()
        {
        }

        public DataTable<TEntity> Paginate(Paginate paginate)
        {
            Request ??= new Request();
            Request.Paginate = paginate;
            return this;
        }

        public DataTable<TEntity> OrderBy(OrderBy order)
        {
            Request ??= new Request();
            Request.OrderBy = order;
            return this;
        }

        public DataTable<TEntity> Draw()
        {
            RecordsTotal = Entities.Count();
            var entities = Entities;
            if (Request.OrderBy != null && entities != null)
            {
                entities = entities.OrderBy(Request.OrderBy);
            }
            if (Request.Paginate != null && entities != null)
            {
                entities = entities.Paginate(Request.Paginate);
            }
            entities ??= default!;
            Data = entities;
            return this; 
        }
    } 
}