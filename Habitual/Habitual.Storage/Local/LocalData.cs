using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Habitual.Storage.Local
{
    public static class LocalData
    {
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }

        #region Setting Constants
        private const string UsernameKey = "username_key";
        private static readonly string UserNameValue = string.Empty;

        private const string PasswordKey = "password_key";
        private static readonly string PasswordValue = string.Empty;
        #endregion

        public static string Username
        {
            get { return AppSettings.GetValueOrDefault<string>(UsernameKey, UserNameValue); }
            set { AppSettings.AddOrUpdateValue<string>(UsernameKey, value); }
        }

        public static string Password
        {
            get { return AppSettings.GetValueOrDefault<string>(PasswordKey, PasswordValue); }
            set { AppSettings.AddOrUpdateValue<string>(PasswordKey, value); }
        }
    }
}
