using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProfileBook.Models;

namespace ProfileBook.Servcies.ProfileService
{
    public interface IProfileService
    {
        Task Dalete(int id);
        Task AddEdit(Profile profile);
        Task<Profile> GetProfile(int id);
        Task<List<Profile>> GetUserProfiles();


    }
}
