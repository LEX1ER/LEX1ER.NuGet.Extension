using LEX1ER.NuGet.Extension.DataSet.Interfaces;
using LEX1ER.NuGet.Extension.DataSet.Test.Models;
using System.Data;

namespace LEX1ER.NuGet.Extension.DataSet.Test
{
    public partial class Tests
    {
        private DataTable<User> DataTable { get; set; } = default!;
        readonly static int Length = 1000;
        private Request Request { get; set; } = new Request()
        {
            Paginate = new Paginate
            {
                Page = 6,
                ItemsPerPage = 36
            },
            OrderBy = new OrderBy
            {
                Sort = [true],
                SortBy = ["Id"]
            }
        };

        [SetUp]
        public void Setup()
        {
            var users = new List<User>();

            for (int i = 1; i <= Length; i++)
            {
                users.Add(new User()
                {
                    Id = i ,
                    Name = $"Name {i}"
                });
            }
            DataTable = new DataTable<User>(users.AsQueryable(), Request);
            DataTable.Draw();
        }

        [Test]
        public void TestDatatableRecordsTotal()
        {
            Assert.ByVal(DataTable.RecordsTotal, Is.EqualTo(Length));
        }

        [Test]
        public void TestDatatableDataCount()
        {
            Assert.ByVal(DataTable.Data.Count(), Is.EqualTo(Request.Paginate.ItemsPerPage));
        }

        [Test]
        public void TestDatatableDataSort()
        {
            Assert.ByVal(DataTable.Data.First().Name, Is.EqualTo($"Name {Length - ((Request.Paginate.Page - 1) * Request.Paginate.ItemsPerPage)}"));
        }
    }
}