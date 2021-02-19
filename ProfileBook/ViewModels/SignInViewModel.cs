using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using ProfileBook.Models;
using ProfileBook.Servcies;
using ProfileBook.Servcies.Settings;

namespace ProfileBook.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        public SignInViewModel(INavigationService navigationService, IRepository<Account> dbRepository, ISettingsManager settingsManager)
        : base(navigationService)
        {
            Title = "Users SignIn";

            _navigationService = navigationService;
            _repository = dbRepository;
            _settingsmanager = settingsManager;

        }


        private readonly INavigationService _navigationService;
        private readonly IRepository<Account> _repository;
        private readonly ISettingsManager _settingsmanager;








        private DelegateCommand _navigateMainListCommand;

       
        public DelegateCommand NavigateMainListCommand =>
            _navigateMainListCommand ?? (_navigateMainListCommand = new DelegateCommand(ExecuteNavigateCommand));


        async void ExecuteNavigateCommand()
        {

            await _navigationService.NavigateAsync("MainList");
        }





        private DelegateCommand _navigateSingUpCommand;
        
        public DelegateCommand NavigateSingUpCommand =>
            _navigateSingUpCommand ?? (_navigateSingUpCommand = new DelegateCommand(ExecuteNavigateSingUpCommand));


        async void ExecuteNavigateSingUpCommand()
        {
            await _navigationService.NavigateAsync("SingUp");
        }








        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }


        private string _login;
        
        public string login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }


        private string _password;
        public string password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        public DelegateCommand ButtonCommand { get; private set; }
        

        

        
       

      
    }
}
