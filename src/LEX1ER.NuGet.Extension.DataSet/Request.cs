using LEX1ER.NuGet.Extension.DataSet.Interfaces;

namespace LEX1ER.NuGet.Extension.DataSet
{
    public class Request : IRequest
    {
        public Paginate Paginate { get; set; } = default!;
        public OrderBy? OrderBy { get; set; }
    }
}
