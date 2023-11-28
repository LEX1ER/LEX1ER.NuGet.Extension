namespace LEX1ER.NuGet.Extension.DataSet.Interfaces
{
    public interface IRequest
    {
        Paginate Paginate { get; set; }
        OrderBy? OrderBy { get; set; }
    }
}
