using System;
using System.Collections.Generic;
using System.Text;
using ProfileBook.Models;

namespace ProfileBook.Servcies.ProfileService
{
    public interface IProfileService
    {
        void Dalete(int id);
        void AddEdit(Profile profile);
        Profile GetProfile(int id);
        IEnumerable<Profile> GetUserProfiles();


    }
}
