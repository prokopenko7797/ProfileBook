using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProfileBook.Servcies;
using ProfileBook.Servcies.Authorization;
using ProfileBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace ProfileBook.ViewModels
{
    public class SingUpViewModel : ViewModelBase
    {

        private readonly IRepository<Account> _repository;
        private readonly INavigationService _navigationService;


        public SingUpViewModel(INavigationService navigationService, IRepository<Account> repository)
            : base(navigationService)
        {
            Title = "Users SignUp";

            tmp = IsEnabled.ToString();
            _repository = repository;
            _navigationService = navigationService;

        }




        #region -----Public Properties-----

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                SetProperty(ref _login, value);

            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);

            }
        }

        private string _confirmpassword;
        public string ConfirmPassword
        {
            get { return _confirmpassword; }
            set
            {
                SetProperty(ref _confirmpassword, value);
            }
        }

        private bool _IsEnabled;

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set 
            {
                SetProperty(ref _IsEnabled, value);

            }
        }


        private string _tmp;
        public string tmp
        {
            get { return _tmp; }
            set
            {
                SetProperty(ref _tmp, value);

            }
        }

        
        private DelegateCommand _AddAccountButtonTapCommand;
        public DelegateCommand AddAccountButtonTapCommand =>
            _AddAccountButtonTapCommand ??
            (_AddAccountButtonTapCommand = 
            new DelegateCommand(ExecuteddAccountButtonTapCommand));



        #endregion


        #region -----Private Helpers-----

        private async void ExecuteddAccountButtonTapCommand()
        {

            // int a = _repository.Insert(new Account { Login = this.Login, Password = this.Password });


            var p = new NavigationParameters();
            p.Add("Login", Login);

                await _navigationService.NavigateAsync("/NavigationPage/SignIn", p);
            
            
        }



        #endregion

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);
            if (args.PropertyName == nameof(Login) || args.PropertyName == nameof(Password) || args.PropertyName == nameof(ConfirmPassword))
            {
                if (Login == null || Password == null || ConfirmPassword == null) return;

                if (Login != "" && Password != "" && ConfirmPassword != "") IsEnabled = true;

                else if (Login == "" || Password == "" || ConfirmPassword == "") IsEnabled = false;
            }
        }

    }
}
