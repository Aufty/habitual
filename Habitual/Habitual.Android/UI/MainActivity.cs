using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Habitual.Android.Presenters;
using Habitual.Android.Presenters.Impl;
using Habitual.Core.Executors.Impl;
using Habitual.Core.Executors;
using Habitual.Android.Threading;
using Habitual.Storage;
using Android.Support.V4.App;

namespace Habitual.Android.UI
{
    [Activity(Label = "Habitual.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity, MainView
    {
        private MainPresenter mainPresenter;
        private MainThread mainThread;

        private EditText username;
        private EditText password;
        private Button testButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Init();
        }

        private void Init()
        {
            mainThread = new MainThreadImpl(this);

            mainPresenter = new MainPresenterImpl(TaskExecutor.GetInstance(), mainThread, this, new UserRepositoryImpl(this));

            username = FindViewById<EditText>(Resource.Id.editText1);
            password = FindViewById<EditText>(Resource.Id.editText2);
            testButton = FindViewById<Button>(Resource.Id.testButton);
            testButton.Click += OnSubmitButtonClicked;
        }

        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            mainPresenter.CreateUser(username.Text, password.Text);
        }

        public void HideProgress()
        {
            throw new NotImplementedException();
        }

        public void OnUserCreated()
        {
            Toast.MakeText(this, "Success!", ToastLength.Short).Show();
        }

        public void ShowError()
        {
            throw new NotImplementedException();
        }

        public void ShowProgress()
        {
            throw new NotImplementedException();
        }
    }
}

