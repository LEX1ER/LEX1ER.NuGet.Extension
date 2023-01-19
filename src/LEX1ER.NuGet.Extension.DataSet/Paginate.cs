using LEX1ER.NuGet.Extension.DataSet.Interfaces;

namespace LEX1ER.NuGet.Extension.DataSet
{
    public class Paginate : IPaginate
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
