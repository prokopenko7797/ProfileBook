using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProfileBook.Servcies;
using ProfileBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProfileBook.ViewModels
{
    public class SingUpViewModel : ViewModelBase
    {
        private readonly IRepository<Account> _repository;

        public SingUpViewModel(INavigationService navigationService, IRepository<Account> repository)
            : base(navigationService)
        {
            Title = "Users SignUp";
            _repository = repository;
        }

        private string _login;
        public string login
        {
            get { return _login; }
            set
            {
                SetProperty(ref _login, value);
            }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
                
            }
        }

        private string _confirmpassword;
        public string confirmpassword
        {
            get { return _confirmpassword; }
            set
            {
                SetProperty(ref _confirmpassword, value);
            }
        }

        private void AddUser()
        {
            int result = _repository.Insert(new Account { Login = login, Password = password });

            
        }

        DelegateCommand AddUserCommand => new DelegateCommand (AddUser);
    }
}
