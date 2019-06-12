using BLL.Services.Interfaces;
using Common.Model;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;

namespace BLL.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository repository;

        public EmailService(IEmailRepository repository)
        {
            this.repository = repository;
        }

        public void Create(Email item)
        {
            repository.Create(item);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public IEnumerable<Email> GetAll()
        {
            return repository.GetAll();
        }

        public Email GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Email item)
        {
            repository.Update(item);
        }
    }
}
