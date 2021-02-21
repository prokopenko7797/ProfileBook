using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProfileBook.Servcies.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileBook.ViewModels
{
    public class MainListViewModel : ViewModelBase
    {

        #region -----Private-----


        private INavigationService _navigationService;
        private ISettingsManager _settingsManager;

        private DelegateCommand _LogOutToolBarCommand;
        private DelegateCommand _AddEditButtonClicked;



        #endregion

        public MainListViewModel(INavigationService navigationService, ISettingsManager settingsManager)
            : base(navigationService)
        {
            Title = "Main List";

            _navigationService = navigationService;
            _settingsManager = settingsManager;
        }


        #region -----Public Properties-----



        public DelegateCommand AddEditButtonClicked =>
            _AddEditButtonClicked ??
            (_AddEditButtonClicked =
            new DelegateCommand(ExecuteNavigateAddEditProfileCommand));


        public DelegateCommand LogOutToolBarCommand =>
            _LogOutToolBarCommand ??
            (_LogOutToolBarCommand =
            new DelegateCommand(ExecuteNavigateLogOutToolBarCommand));



        #endregion




        #region -----Private Helpers-----

        private async void ExecuteNavigateAddEditProfileCommand()
        {
            await _navigationService.NavigateAsync("AddEditProfile");

        }


        private async void ExecuteNavigateLogOutToolBarCommand() 
        {
            _settingsManager.IdUser = -1;
            await _navigationService.NavigateAsync("/NavigationPage/SingIn");
        }

        #endregion

    }
}
