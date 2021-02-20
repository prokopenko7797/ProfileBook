using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using ProfileBook.Models;
using ProfileBook.Servcies;
using ProfileBook.Servcies.Settings;
using ProfileBook.Servcies.Authorization;
using System.ComponentModel;

namespace ProfileBook.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {


        public SignInViewModel(INavigationService navigationService, IRepository<Account> dbRepository, 
            ISettingsManager settingsManager, IAuthorization authorization)
        : base(navigationService)
        {
            Title = "Users SignIn";
            
            
            _navigationService = navigationService;
            _repository = dbRepository;
            _settingsmanager = settingsManager;
            _authorization = authorization;


        }


        private readonly INavigationService _navigationService;
        private readonly IRepository<Account> _repository;
        private readonly ISettingsManager _settingsmanager;
        private readonly IAuthorization _authorization;



        #region -----Public Properties-----

        private string _Login;

        public string Login
        {
            get { return _Login; }
            set
            {

                SetProperty(ref _Login, value);

                if (Login == null || Password == null) return;

                if (Login != "" && Password != "") IsEnabled = true;

                else if (Login == "") IsEnabled = false;

            }
        }


        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                SetProperty(ref _Password, value);
                if (Login == null || Password == null) return;

                if (Login != "" && Password != "") IsEnabled = true;

                else if (Password == "") IsEnabled = false;
            }
        }


        private bool _IsEnabled;

        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { SetProperty(ref _IsEnabled, value); }
        }


        private string _tmp;

        public string tmp
        {
            get { return _tmp; }
            set { SetProperty(ref _tmp, value); }
        }



        private DelegateCommand _NavigateMainListCommand;
        
        public DelegateCommand NavigateMainListButtonTapCommand =>
            _NavigateMainListCommand ?? 
            (_NavigateMainListCommand = new DelegateCommand(ExecuteNavigateMainViewCommand).ObservesCanExecute(() => IsEnabled));


        private DelegateCommand _NavigateSingUpCommand;

        public DelegateCommand NavigateSingUpButtonTapCommand =>
            _NavigateSingUpCommand ?? 
            (_NavigateSingUpCommand = new DelegateCommand(ExecuteNavigateSingUpCommand));

        #endregion




        #region -----Private Helpers-----

        private async void ExecuteNavigateSingUpCommand()
        {
            await _navigationService.NavigateAsync("SingUp");

        }

        private async void ExecuteNavigateMainViewCommand()
        {
            //if (_authorization.Authorize(Login, Password))
            //{
                await _navigationService.NavigateAsync("/NavigationPage/MainList");
            //}
        }

        #endregion


        #region -----Overrides-----



        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if(parameters.GetValue<string>("Login") != null)
                 Login = parameters.GetValue<string>("Login");

            Password = "";

        }

    


        #endregion

    }
}
