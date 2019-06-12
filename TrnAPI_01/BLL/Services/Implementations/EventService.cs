using BLL.Services.Interfaces;
using Common.Model;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace BLL.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IEventRepository repository;

        public EventService(IEventRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Event item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Event> GetAll()
        {
            return repository.GetAll();
        }

        public Event GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Event> GetEventsByRecordId(int recordId)
        {
            return repository.GetEventsByRecordId(recordId);
        }

        public void Update(Event item)
        {
            repository.Update(item);
        }
    }
}
