﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProfileBook.Models;
using ProfileBook.Servcies.Repository;
using ProfileBook.Servcies.Settings;
using Xamarin.Essentials;

namespace ProfileBook.Servcies.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IRepository<User> _repository;
        private readonly ISettingsManager _settingsManager;

        public AuthorizationService(IRepository<User> repository, ISettingsManager settingsManager)
        {
            _repository = repository;
            _settingsManager = settingsManager;
        }
        public async Task<bool> Authorize(string login, string password)
        {

            var user = await _repository.FindWithQuery($"SELECT * FROM User WHERE login='{login}' AND password='{password}'");

            if(user != null)
            {
                _settingsManager.IdUser = user.id;
                return true;
            }

            return false;
        }
    }
}
