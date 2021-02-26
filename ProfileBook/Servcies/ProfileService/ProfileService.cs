using ProfileBook.Models;
using ProfileBook.Servcies.Repository;
using ProfileBook.Servcies.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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


        public async Task<bool> AddEdit(Profile profile)
        {
            if (profile.id != default)
            { 
                if (await _repository.Update(profile) != -1)
                    return true; 
            }
            else
            {
                if (await _repository.Insert(profile) != -1)
                    return true;
            }
            return false;
        }

        public async Task<bool> Dalete(int id) 
        {
            if (await _repository.Delete(id) != -1)
                return true;
            else return false;
        }

        public async Task<Profile> GetProfile(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<Profile>> GetUserProfiles()
        {
            return await _repository.Query($"SELECT * FROM {nameof(Profile)} WHERE user_id='{_settingsManager.IdUser}'");
        }
    }
}
