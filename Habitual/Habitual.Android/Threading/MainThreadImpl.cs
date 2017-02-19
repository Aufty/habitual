using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Habitual.Core.Executors;
using Android.Support.V7.App;
using Android.Support.V4.App;

namespace Habitual.Android.Threading
{
    public class MainThreadImpl : MainThread
    {
        private FragmentActivity activity;

        public MainThreadImpl(FragmentActivity activity) : base()
        {
            this.activity = activity;
        }

        public void Post(Action action)
        {
            activity.RunOnUiThread(action);
        }

        public void Post<T>(Action<T> action)
        {
            throw new NotImplementedException();
        }
    }
}