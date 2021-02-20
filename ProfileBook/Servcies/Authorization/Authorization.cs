using System;
using System.Collections.Generic;
using System.Text;
using ProfileBook.Models;
using ProfileBook.Servcies.Settings;
using Xamarin.Essentials;

namespace ProfileBook.Servcies.Authorization
{
    public class Authorization : IAuthorization
    {
        private readonly IRepository<Account> _repository;
        private readonly ISettingsManager _settingsManager;

        public Authorization(IRepository<Account> repository, ISettingsManager settingsManager)
        {
            _repository = repository;
            _settingsManager = settingsManager;
        }
        public bool Authorize(string login, string password)
        {

            Account ac = _repository.FindWithQuery($"SELECT * FROM Account WHERE login='{login}' AND password='{password}'");

            if(ac != null)
            {
                _settingsManager.IdUser = ac.id;
                return true;
            }

            return false;
        }
    }
}
