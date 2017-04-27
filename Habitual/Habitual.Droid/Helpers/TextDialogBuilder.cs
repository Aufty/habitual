using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Text;
using Android;
using Habitual.Droid.Util;

namespace Habitual.Droid.Helpers
{

    public class TextDialogBuilder
    {

        public AlertDialog BuildLoginDialog(Activity activity, Action<string, string> loginMethod, Action<string,string> registerMethod)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(activity);

            LayoutInflater inflater = activity.LayoutInflater;

            builder.SetTitle("Login / Registration Required");

            var view = inflater.Inflate(Resource.Layout.LoginDialog, null);
            var username = view.FindViewById<EditText>(Resource.Id.login_username);
            var password = view.FindViewById<TextView>(Resource.Id.login_password);

            PasswordHasher hasher = new PasswordHasher();
            var hashedPassword = hasher.HashPassword(password.Text);

            builder.SetView(view);
            builder.SetPositiveButton("LOGIN", new EventHandler<DialogClickEventArgs>((s, args) =>
            {
                if (username.Text == null || password.Text == null)
                {
                    // do nothing
                }
                loginMethod(username.Text, hashedPassword);
            }));
            builder.SetNegativeButton("REGISTER", new EventHandler<DialogClickEventArgs>((s, args) =>
            {
                if (username.Text == null || password.Text == null)
                {
                    // do nothing
                }
                registerMethod(username.Text, hashedPassword);
            }));

            return builder.Create();
        }
    }
}