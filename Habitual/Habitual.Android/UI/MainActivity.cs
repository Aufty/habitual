using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Habitual.Droid.Presenters;
using Habitual.Droid.Presenters.Impl;
using Habitual.Core.Executors.Impl;
using Habitual.Core.Executors;
using Habitual.Droid.Threading;
using Habitual.Storage;
using Android.Support.V7.App;
using Android.Views;
using Habitual.Droid.Util;

namespace Habitual.Droid.UI
{
    [Activity(Label = "Habitual.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity, MainView
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
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SetupTabs();
            Init();
        }

        private void SetupTabs()
        {
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.mainMenu, menu);
            return true;
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
            PasswordHasher hasher = new PasswordHasher();
            mainPresenter.CreateUser(username.Text, hasher.HashPassword(password.Text));
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

