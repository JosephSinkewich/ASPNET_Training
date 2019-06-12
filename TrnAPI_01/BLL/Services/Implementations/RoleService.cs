using BLL.Services.Interfaces;
using Common.Model;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace BLL.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository repository;

        public RoleService(IRoleRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Role item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return repository.GetAll();
        }

        public Role GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Role item)
        {
            repository.Update(item);
        }
    }
}
