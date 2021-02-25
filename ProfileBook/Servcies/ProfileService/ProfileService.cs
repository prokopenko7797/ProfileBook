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


        public async Task AddEdit(Profile profile)
        {
            if (profile.id != default)
                await _repository.Update(profile);
            else
            {
                profile.user_id = _settingsManager.IdUser;
                profile.date = DateTime.Now;
                await _repository.Insert(profile);
            }
        }

        public async Task Dalete(int id) 
        {
            await _repository.Delete(id);
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
