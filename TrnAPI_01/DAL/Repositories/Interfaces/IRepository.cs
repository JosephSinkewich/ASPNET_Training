using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
