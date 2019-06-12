using BLL.Services.Interfaces;
using Common.Model;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace BLL.Services.Implementations
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository repository;

        public PictureService(IPictureRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Picture item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Picture> GetAll()
        {
            return repository.GetAll();
        }

        public Picture GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Picture item)
        {
            repository.Update(item);
        }
    }
}
