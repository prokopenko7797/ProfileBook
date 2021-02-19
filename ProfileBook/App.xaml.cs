using Prism;
using Prism.Ioc;
using ProfileBook.ViewModels;
using ProfileBook.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using ProfileBook.Servcies;
using ProfileBook.Models;
using System.IO;
using System.Threading.Tasks;



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
            

            await NavigationService.NavigateAsync("NavigationPage/SignIn");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {


            containerRegistry.RegisterInstance<IRepository<Account>>(Container.Resolve<Repository<Account>>());
            containerRegistry.RegisterInstance<IRepository<Profile>>(Container.Resolve<Repository<Profile>>());

            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

       
            containerRegistry.RegisterForNavigation<SignIn, SignInViewModel>();
            containerRegistry.RegisterForNavigation<SingUp, SingUpViewModel>();
            containerRegistry.RegisterForNavigation<MainList, MainListViewModel>();
        }
    }
}
