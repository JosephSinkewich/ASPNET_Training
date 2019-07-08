using BLL.Services.Interfaces;
using Common.Model;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace BLL.Services.Implementations
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository repository;

        public RecordService(IRecordRepository repository)
        {
            this.repository = repository;
        }

        public void AddEvent(int recordId, int eventId)
        {
            repository.AddEvent(recordId, eventId);
        }

        public void RemoveEvent(int recordId, int eventId)
        {
            repository.RemoveEvent(recordId, eventId);
        }

        public void Create(Record item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Record> GetAll()
        {
            return repository.GetAll();
        }

        public Record GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Record> GetRecordsByCategoryId(int categoryId)
        {
            return repository.GetRecordsByCategoryId(categoryId);
        }

        public void Update(Record item)
        {
            repository.Update(item);
        }
    }
}
