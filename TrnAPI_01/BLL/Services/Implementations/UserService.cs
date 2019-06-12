using BLL.Services.Interfaces;
using Common.Model;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public void Create(User item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }

        public User GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(User item)
        {
            repository.Update(item);
        }
    }
}
