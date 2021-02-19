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
            get=>Preferences.Get(nameof (IdUser), -1);
            set=>Preferences.Set(nameof(IdUser), value); 
        }
    }
}
