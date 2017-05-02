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
    public interface MainApplicationCallback
    {
        void UserUpdateRequested();
        void UpdateAllRequested();
    }

    [Activity(Label = "Habitual.Droid", MainLauncher = true, Icon = "@drawable/ic_launcher", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity, MainView, MainApplicationCallback
    {
        private MainPresenter mainPresenter;
        private MainThread mainThread;
        private IMenuItem refreshItem;
        private MainFragmentPagerAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
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
            }
            else
            {
                PromptLoginOrRegister();
            }
        }

        private void PromptLoginOrRegister()
        {
            TextDialogBuilder builder = new TextDialogBuilder();
            var dialog = builder.BuildLoginDialog(this, mainPresenter.GetUser, mainPresenter.CreateUser);
            dialog.Show();
        }

        private void SetupTabControl()
        {
            adapter = new MainFragmentPagerAdapter(SupportFragmentManager, this);
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.currentFragmentViewPager);
            viewPager.Adapter = adapter;

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
            }
            else
            {
                // open settings
            }
            return true;
        }

        private void Init()
        {
            mainThread = new MainThreadImpl(this);

            mainPresenter = new MainPresenterImpl(TaskExecutor.GetInstance(), mainThread, this, new UserRepositoryImpl());
        }

        public void HideProgress()
        {
            throw new NotImplementedException();
        }

        public void OnUserCreated(User user)
        {
            Toast.MakeText(this, string.Format("User {0} created!", user.Username), ToastLength.Short).Show();

            mainPresenter.StoreUserLocal(user);

            UpdateInterfaceWithUser(user);
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
            if (user == null)
            {
                RunOnUiThread(() =>
                {
                    PromptLoginOrRegister();
                });
                return;
            }
            mainPresenter.StoreUserLocal(user);

            UpdateInterfaceWithUser(user);
        }

        private void UpdateInterfaceWithUser(User user)
        {
            var imageBitmap = BitmapFactory.DecodeByteArray(user.Avatar, 0, user.Avatar.Length);
            RunOnUiThread(() =>
            {
                FindViewById<TextView>(Resource.Id.userNameText).Text = user.Username;
                FindViewById<TextView>(Resource.Id.pointsText).Text = user.Points.ToString();
                FindViewById<ImageView>(Resource.Id.avatar).SetImageBitmap(imageBitmap);
            });

            adapter.UpdateFragments();
        }

        public void OnUserStored(User user)
        {
            Toast.MakeText(this, "User stored locally", ToastLength.Short).Show();
        }

        public void UserUpdateRequested()
        {
            mainPresenter.GetPoints(LocalData.Username, LocalData.Password);
        }

        public void OnPointsRetrieved(int points)
        {
            FindViewById<TextView>(Resource.Id.pointsText).Text = points.ToString();
        }

        public void UpdateAllRequested()
        {
            adapter.UpdateFragments();
        }
    }
}

