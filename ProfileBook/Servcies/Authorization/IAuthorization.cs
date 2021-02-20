using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileBook.Servcies.Authorization
{
    public interface IAuthorization
    {
        bool Authorize(string login, string password);
    }
}
