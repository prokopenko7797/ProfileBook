using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProfileBook.Servcies;
using System;
using System.Collections.Generic;
using System.Linq;
using ProfileBook.Models;

namespace ProfileBook.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly IRepository<Account> _repository;


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




        public SignInViewModel(INavigationService navigationService, IDbRepository dbRepository)
            : base(navigationService)
        {
            Title = "Users SignIn";

            _navigationService = navigationService;
            _dbrepository = dbRepository;
           


        }



        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        private string _login;
        private string _password;

        public string login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        public string password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        public DelegateCommand ButtonCommand { get; private set; }
        

        

        
       

      
    }
}
