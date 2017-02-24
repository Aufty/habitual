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
using Habitual.Droid.UI;
using Habitual.Core.Entities;

namespace Habitual.Droid.Presenters
{
    public interface MainView : BaseView
    {
        void OnUserCreated();
    }

    public interface MainPresenter : BasePresenter
    {
        void CreateUser(string username, string hashedPassword);
    }
}