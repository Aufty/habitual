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
using Android.Support.V4.View;
using Android.Support.Design.Widget;

namespace Habitual.Droid.UI
{
    [Activity(Label = "Habitual.Droid", MainLauncher = true, Icon = "@drawable/ic_launcher", Theme = "@style/MyTheme")]
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
            SetupTabControl();
            Init();
        }

        private void SetupTabControl()
        {
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.currentFragmentViewPager);
            viewPager.Adapter = new MainFragmentPagerAdapter(SupportFragmentManager, this);

            TabLayout tabLayout = FindViewById<TabLayout>(Resource.Id.tabControl);
            tabLayout.SetupWithViewPager(viewPager);
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

