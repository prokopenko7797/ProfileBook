using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using ProfileBook.Servcies;
using ProfileBook.Models;
using System.ComponentModel;
using ProfileBook.Enums;
using ProfileBook.Servcies.Registration;


namespace ProfileBook.ViewModels
{
    public class SingUpViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly IRegistrationService _registrationService;




        public SingUpViewModel(INavigationService navigationService, IRepository<User> repository,
            IPageDialogService pageDialogService, IRegistrationService registrationService)
            : base(navigationService)
        {
            Title = "Users SignUp";

            
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _registrationService = registrationService;

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

        
        private DelegateCommand _AddUserButtonTapCommand;
        public DelegateCommand AddUserButtonTapCommand =>
            _AddUserButtonTapCommand ??
            (_AddUserButtonTapCommand = 
            new DelegateCommand(ExecuteddUserButtonTapCommand)).ObservesCanExecute(() => IsEnabled);



        #endregion


        #region -----Private Helpers-----

        private async void ExecuteddUserButtonTapCommand()
        {
            switch (_registrationService.Registrate(Login, Password, ConfirmPassword))
            {
                case ValidEnum.NotInRangeLogin:
                    {
                        await _pageDialogService.DisplayAlertAsync(
                        "Error", "Login must be at least 4 and no more than 16 characters.", "OK");
                    }
                    break;

                case ValidEnum.NotInRangePassword:
                    {
                        await _pageDialogService.DisplayAlertAsync(
                        "Error", "Password must be at least 8 and no more than 16 characters.", "OK");
                    }
                    break;
                case ValidEnum.HasntMach:
                    {
                        await _pageDialogService.DisplayAlertAsync(
                        "Error", "Password mismatch.", "OK");
                    }
                    break;
                case ValidEnum.HasntUpLowNum:
                    {
                        await _pageDialogService.DisplayAlertAsync(
                        "Error", "Password must contain at least one uppercase letter, one lowercase letter and one number.", "OK");
                    }
                    break;

                case ValidEnum.StartWithNum:
                    {
                        await _pageDialogService.DisplayAlertAsync(
                        "Error", "Login should not start with number.", "OK");
                    }
                    break;
                case ValidEnum.LoginExist:
                    {
                        await _pageDialogService.DisplayAlertAsync(
                        "Error", "Login already exist.", "OK");
                    }
                    break;
                case ValidEnum.Success:
                    {

                        var p = new NavigationParameters();
                        p.Add("Login", Login);

                        await _navigationService.NavigateAsync("/NavigationPage/SignIn", p);
                    }
                    break;
                default:
                    {
                        await _pageDialogService.DisplayAlertAsync(
                            "Error", "Unknown error", "OK");
                    }
                    break;

            }
         
            
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
