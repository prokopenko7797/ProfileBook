using ProfileBook.Constants;
using ProfileBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ProfileBook.Servcies.Settings
{
    public class SettingsManager: ISettingsManager
    {
        public int IdUser 
        { 
            get=>Preferences.Get(nameof (IdUser), Constant.NonAuthorized);
            set=>Preferences.Set(nameof(IdUser), value); 
        }

        public int SortBy
        {
            get => Preferences.Get(nameof(SortBy), Constant.DefaultSort);
            set => Preferences.Set(nameof(SortBy), value);
        }

        public int Lang
        {
            get => Preferences.Get(nameof(Lang), Constant.DefaultLanguage);
            set => Preferences.Set(nameof(Lang), value);
        }

        public string Theme
        {
            get => Preferences.Get(nameof(Theme), Constant.DefaultTheme);
            set => Preferences.Set(nameof(Theme), value);
        }
    }
}
