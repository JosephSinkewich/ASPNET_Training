using BLL.Services.Interfaces;
using Common.Model;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace BLL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;

        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Category item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return repository.GetAll();
        }

        public Category GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Category item)
        {
            repository.Update(item);
        }
    }
}
