using System.Collections.Generic;

namespace BLL.Services.Interfaces
{
    public interface IService<T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
