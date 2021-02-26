using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProfileBook.Models;
using ProfileBook.Servcies.ProfileService;
using ProfileBook.Servcies.Settings;
using ProfileBook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProfileBook.ViewModels
{
    public class MainListViewModel : ViewModelBase
    {

        #region -----Private-----


        private readonly INavigationService _navigationService;
        private readonly ISettingsManager _settingsManager;
        private readonly IProfileService _profileService;

        private DelegateCommand _LogOutToolBarCommand;
        private DelegateCommand _AddEditButtonClicked;


        private ObservableCollection<Profile> _profileList;
        private Profile _selectedProfile;


        private string _tmp;
        private bool _IsVisible;
        

        #endregion

        public MainListViewModel(INavigationService navigationService, ISettingsManager settingsManager, 
            IProfileService profileService)
            : base(navigationService)
        {
            Title = "Main List";
            

            _navigationService = navigationService;
            _settingsManager = settingsManager;
            _profileService = profileService;

            

        }


        #region -----Public Properties-----


        public ObservableCollection<Profile> ProfileList 
        {
            get { return _profileList; }
            set { SetProperty(ref _profileList, value); }
        }


        public Profile selectedProfile
        {
            get { return _selectedProfile; }
            set { SetProperty(ref _selectedProfile, value); }
        }



        public string tmp
        {
            get { return _tmp; }
            set { SetProperty(ref _tmp, value); }
        }



        public bool IsVisible
        {
            get { return _IsVisible; }
            set { SetProperty(ref _IsVisible, value); }
        }


        

        public DelegateCommand AddEditButtonClicked =>
            _AddEditButtonClicked ??
            (_AddEditButtonClicked =
            new DelegateCommand(ExecuteNavigateAddEditProfileCommand));


        public DelegateCommand LogOutToolBarCommand =>
            _LogOutToolBarCommand ??
            (_LogOutToolBarCommand =
            new DelegateCommand(ExecuteNavigateLogOutToolBarCommand));


        public ICommand EditTap => new Command(Delete);
        public ICommand DeleteTap => new Command(Edit);


        #endregion




        #region -----Private Helpers-----


        private async void Delete(object sender)
        {
            Profile profile = sender as Profile;
            if (profile == null) return;
            var result = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
            {
                Message = "Delete?",
                OkText = "Yes",
                CancelText = "No"
            });
            if (result)
            {
                await _profileService.Dalete(profile.id);
                ProfileList = new ObservableCollection<Profile>(await _profileService.GetUserProfiles());
            }
        }


        private async void Edit(object sender)
        {
            Profile profile = sender as Profile;
            if (profile == null) return;

            var p = new NavigationParameters();
            p.Add("profile", profile);

            await _navigationService.NavigateAsync($"{nameof(AddEditProfile)}", p);
        }


        private void ProfileSelect(Profile profile)
        {
            // add modal image
        }


        private async void ExecuteNavigateAddEditProfileCommand()
        {
            await _navigationService.NavigateAsync($"{nameof(AddEditProfile)}");

        }


        private async void ExecuteNavigateLogOutToolBarCommand() 
        {
            _settingsManager.IdUser = -1;
            await _navigationService.NavigateAsync($"/NavigationPage/{nameof(SignIn)}");
        }

        #endregion


        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);


            ProfileList = new ObservableCollection<Profile>(await _profileService.GetUserProfiles());
            if (ProfileList.Count() != 0) IsVisible = false;
            else IsVisible = true;
        }

    }
}
