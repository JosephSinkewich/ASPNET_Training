using Common.Model;
using System.Collections.Generic;

namespace BLL.Services.Interfaces
{
    public interface IEventService : IService<Event>
    {
        IEnumerable<Event> GetEventsByRecordId(int recordId);
    }
}
