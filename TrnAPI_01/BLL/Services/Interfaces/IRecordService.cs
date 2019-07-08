using Common.Model;
using System.Collections.Generic;

namespace BLL.Services.Interfaces
{
    public interface IRecordService:IService<Record>
    {
        IEnumerable<Record> GetRecordsByCategoryId(int categoryId);
        void AddEvent(int recordId, int eventId);
        void RemoveEvent(int recordId, int eventId);
    }
}
