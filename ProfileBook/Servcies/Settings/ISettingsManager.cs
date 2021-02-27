using ProfileBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProfileBook.Servcies.Settings
{
    public interface ISettingsManager
    {
        int IdUser { get; set; }
        int SortBy { get; set; }
        int Lang { get; set; }
        string Theme { get; set; }
    }
}
