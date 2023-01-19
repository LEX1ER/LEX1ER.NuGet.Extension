using LEX1ER.NuGet.Extension.DataSet.Interfaces;

namespace LEX1ER.NuGet.Extension.DataSet
{
    public class OrderBy : IOrderBy
    {
        public bool[] Sort { get; set; } = default!;
        public string[] SortBy { get; set; } = default!;
    }
}
