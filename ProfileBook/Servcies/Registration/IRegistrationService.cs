using ProfileBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileBook.Servcies.Registration
{
    public interface IRegistrationService
    {
        ValidEnum Registrate(string login, string password, string confirmpassword);
    }
}
