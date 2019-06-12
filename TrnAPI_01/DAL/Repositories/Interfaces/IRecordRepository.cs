using Common.Model;
using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IRecordRepository : IRepository<Record>
    {
        IEnumerable<Record> GetRecordsByCategoryId(int categoryId);
    }
}
