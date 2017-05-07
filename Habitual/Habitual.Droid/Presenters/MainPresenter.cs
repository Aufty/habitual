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
using Android.Net;

namespace Habitual.Droid.Presenters
{
    public interface MainView : BaseView
    {
        void OnUserCreated(User user);
        void OnUserRetrieved(User user);
        void OnUserStored(User user);
        void OnPointsRetrieved(int points);
        void OnAvatarSet(string imageString);
        void OnError(string message);
    }

    public interface MainPresenter : BasePresenter
    {
        void CreateUser(string username, string hashedPassword);
        void GetUser(string username, string hashedPassword);
        void StoreUserLocal(User user);
        void GetPoints(string username, string password);
        void SetAvatar(string username, string imageString);
    }
}