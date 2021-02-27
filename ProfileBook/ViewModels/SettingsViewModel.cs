using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProfileBook.Constants;
using ProfileBook.Servcies.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileBook.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ISettingsManager _settingsManager;
        private readonly IUserDialogs _userDialogs;
        private readonly INavigationService _navigationService;

        public SettingsViewModel(INavigationService navigationService, ISettingsManager settingsManager, IUserDialogs userDialogs)
            : base(navigationService)
        {
            _settingsManager = settingsManager;
            _userDialogs = userDialogs;
            _navigationService = navigationService;

        }

 

        private int _Selection;

        public int Selection
        {
            get { return _Selection; }
            set { SetProperty(ref _Selection, value); }
        }

        private string _Theme;

        public string Theme
        {
            get { return _Theme; }
            set { SetProperty(ref _Theme, value); }
        }

        private int _Lang;

        public int Lang
        {
            get { return _Lang; }
            set { SetProperty(ref _Lang, value); }
        }


        private DelegateCommand _SaveToolBarCommand;

        public DelegateCommand SaveToolBarCommand =>
           _SaveToolBarCommand ??
           (_SaveToolBarCommand = new DelegateCommand(SaveToolBar));


        private async void SaveToolBar()
        {
            _settingsManager.SortBy = Selection;

            _settingsManager.Theme = Theme;

            _settingsManager.Lang = Lang;

            await _navigationService.GoBackAsync();
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Selection = _settingsManager.SortBy;

            Theme = _settingsManager.Theme;

            Lang = _settingsManager.Lang;
        }
    }
}
