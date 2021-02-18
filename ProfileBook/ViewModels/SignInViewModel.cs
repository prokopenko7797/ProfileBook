using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileBook.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        public SignInViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Users SignIn";
        }
    }
}
