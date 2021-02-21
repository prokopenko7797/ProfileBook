using ProfileBook.Enums;
using ProfileBook.Models;
using ProfileBook.Servcies.Repository;
using ProfileBook.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileBook.Servcies.Registration
{
    public class RegistrationService : IRegistrationService
    {

        private readonly IRepository<User> _repository;
        private readonly IValidator _validator;


        public RegistrationService(IRepository<User> repository, IValidator validator)
        {
            _repository = repository;
            _validator = validator;

        }



        public ValidEnum  Registrate(string login, string password, string confirmpassword)
        {
            if (!_validator.InRange(login, 4, 16))
            {   
                return ValidEnum.NotInRangeLogin;
            }

            if (!_validator.InRange(password, 8, 16))
            {
                return ValidEnum.NotInRangePassword;
            }


            if (_validator.StartWithNumeral(login))
            {       
                return ValidEnum.StartWithNum;
            }

            if (!_validator.HasUpLowNum(password))
            {
                return ValidEnum.HasntUpLowNum;
            }



            if (!_validator.Match(password, confirmpassword))
            {
                
                return ValidEnum.HasntMach;
            }



            User user = _repository.FindWithQuery($"SELECT * FROM User WHERE login='{login}'");

            if (user != null)
            {
                
                return ValidEnum.LoginExist;
            }

            _repository.Insert(new User { Login = login, Password = password });
            return ValidEnum.Success;
        }
    }
}
