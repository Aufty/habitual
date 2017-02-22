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

namespace Habitual.Droid.UI
{
    public interface BaseView
    {
        void ShowProgress();

        void HideProgress();

        void ShowError();
    }
}