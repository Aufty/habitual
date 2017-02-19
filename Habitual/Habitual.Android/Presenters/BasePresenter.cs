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

namespace Habitual.Android.Presenters
{
    public interface BasePresenter
    {
        /// <summary>
        /// Should be called in OnResume() of Activity or Fragment
        /// </summary>
        void Resume();

        /// <summary>
        /// Should be called in OnPause() of Activity or Fragment
        /// </summary>
        void Pause();

        /// <summary>
        /// Should be called in OnStop() of Activity or Fragment
        /// </summary>
        void Stop();

        /// <summary>
        /// Should be called in OnDestroy() of Activity or Fragment
        /// </summary>
        void Destroy();

        /// <summary>
        /// Should signal the appropriate view to show the error message provided
        /// </summary>
        void OnError(string message);
    }
}