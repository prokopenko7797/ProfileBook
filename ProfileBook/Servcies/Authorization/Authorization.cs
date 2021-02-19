using System;
using System.Collections.Generic;
using System.Text;
using ProfileBook.Models;

namespace ProfileBook.Servcies.Authorization
{
    class Authorization : IAuthorization
    {
        private readonly IRepository<Account> _repository;

        public Authorization(IRepository<Account> repository)
        {
            _repository = repository;
        }
        public bool Authorize(string login, string password)
        {
            bool result = false;
            //_repository.Get().FirstOrDefault(x => x.Login == login && x.Password == password);
            return result;
        }
    }
}
