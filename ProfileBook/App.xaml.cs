using Prism;
using Prism.Ioc;
using ProfileBook.ViewModels;
using ProfileBook.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using ProfileBook.Servcies;
using ProfileBook.Servcies.Settings;
using ProfileBook.Servcies.Authorization;
using ProfileBook.Models;
using System.IO;
using System.Threading.Tasks;
using ProfileBook.Validators;
using ProfileBook.Servcies.Registration;
using Xamarin.Essentials;

namespace ProfileBook
{
    public partial class App
    {
        
     
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            //if(Preferences.Get("IdUser", -1) != -1) 
                await NavigationService.NavigateAsync("NavigationPage/SignIn");
            //else await NavigationService.NavigateAsync("NavigationPage/MainList");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            

            containerRegistry.RegisterInstance<IRepository<User>>(Container.Resolve<Repository<User>>());
            containerRegistry.RegisterInstance<IRepository<Profile>>(Container.Resolve<Repository<Profile>>());
            containerRegistry.RegisterInstance <ISettingsManager>(Container.Resolve <SettingsManager>());
            containerRegistry.RegisterInstance<IAuthorizationService>(Container.Resolve<AuthorizationService>());
            containerRegistry.RegisterInstance<IValidator>(Container.Resolve<Validator>());
            containerRegistry.RegisterInstance<IRegistrationService>(Container.Resolve<RegistrationService>());




            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SignIn, SignInViewModel>();
            containerRegistry.RegisterForNavigation<SingUp, SingUpViewModel>();
            containerRegistry.RegisterForNavigation<MainList, MainListViewModel>();
            containerRegistry.RegisterForNavigation<AddEditProfile, AddEditProfileViewModel>();
        }
    }
}
