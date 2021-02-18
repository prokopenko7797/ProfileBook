using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileBook.ViewModels
{
    public class SingUpViewModel : ViewModelBase
    {
        public SingUpViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Users SignUp";
        }
    }
}
