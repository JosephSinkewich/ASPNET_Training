using Common.Model;
using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetEventsByRecordId(int recordId);
    }
}
