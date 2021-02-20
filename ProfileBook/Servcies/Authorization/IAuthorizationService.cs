using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileBook.Servcies.Authorization
{
    public interface IAuthorizationService
    {
        bool Authorize(string login, string password);
    }
}
