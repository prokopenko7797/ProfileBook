using ProfileBook.Models;
using ProfileBook.Servcies.Repository;
using ProfileBook.Servcies.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileBook.Servcies.ProfileService
{
    public class ProfileService: IProfileService
    {
        private readonly IRepository<Profile> _repository;
        private readonly ISettingsManager _settingsManager;

        public ProfileService(IRepository<Profile> repository, ISettingsManager settingsManager)
        {
            _repository = repository;
            _settingsManager = settingsManager;
    }


        public void AddEdit(Profile profile)
        {
            if (profile.id != -1)
                _repository.Update(profile);
            else
            {
                profile.date = DateTime.Now;
                _repository.Insert(profile);
            }
        }

        public void Dalete(int id) 
        {
            _repository.Delete(id);
        }

        public Profile GetProfile(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Profile> GetUserProfiles()
        {
            return _repository.Query($"SELECT * FROM User WHERE user_id='{_settingsManager.IdUser.ToString()}'");
        }
    }
}
