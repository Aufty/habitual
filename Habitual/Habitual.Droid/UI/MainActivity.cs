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
using Habitual.Storage.Local;
using Habitual.Core.UseCases;
using Habitual.Core.UseCases.Impl;
using Habitual.Core.Entities;
using Android.Graphics;
using Habitual.Droid.Helpers;

namespace Habitual.Droid.UI
{
    [Activity(Label = "Habitual.Droid", MainLauncher = true, Icon = "@drawable/ic_launcher", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity, MainView
    {
        private MainPresenter mainPresenter;
        private MainThread mainThread;
        private IMenuItem refreshItem;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //TODO: get rid of this
            Storage.Local.LocalData.Username = "";
            Storage.Local.LocalData.Password = "password";

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SetupTabControl();
            Init();
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (!string.IsNullOrEmpty(LocalData.Username.Trim()))
            {
                mainPresenter.GetUser(LocalData.Username, LocalData.Password);
            } else
            {
                PromptLoginOrRegister();
            }
        }

        private void PromptLoginOrRegister()
        {
            TextDialogBuilder builder = new TextDialogBuilder();
            var dialog = builder.BuildLoginDialog(this, mainPresenter.GetUser, mainPresenter.GetUser);
            dialog.Show();
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

            refreshItem = menu.FindItem(Resource.Id.refresh);
            refreshItem.SetIcon(Resource.Drawable.refresh);
            refreshItem.SetShowAsAction(ShowAsAction.Always);
            
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            base.OnOptionsItemSelected(item);
            if (item == refreshItem)
            {
                // refresh
            } else
            {
                // open settings
            }
            return true;
        }

        private void Init()
        {
            mainThread = new MainThreadImpl(this);

            mainPresenter = new MainPresenterImpl(TaskExecutor.GetInstance(), mainThread, this, new UserRepositoryImpl(this));

        }


        //private void OnSubmitButtonClicked(object sender, EventArgs e)
        //{
        //    PasswordHasher hasher = new PasswordHasher();
        //    mainPresenter.CreateUser(username.Text, hasher.HashPassword(password.Text));
        //}

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

        public void OnUserRetrieved(User user)
        {
            FindViewById<TextView>(Resource.Id.userNameText).Text = user.Username;
            FindViewById<TextView>(Resource.Id.pointsText).Text = user.Points.ToString();
            var imageBitmap = BitmapFactory.DecodeByteArray(user.Avatar, 0, user.Avatar.Length);
            RunOnUiThread(() => FindViewById<ImageView>(Resource.Id.avatar).SetImageBitmap(imageBitmap));
        }
    }
}

