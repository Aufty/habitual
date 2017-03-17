using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Habitual.Droid.UI;
using Java.Lang;
using JavaString = Java.Lang.String;

namespace Habitual.Droid.Util
{
    public class MainFragmentPagerAdapter : FragmentPagerAdapter
    {
        private static int PAGE_COUNT = 3;
        private JavaString[] tabTitles = new JavaString[] { new JavaString("Overview"), new JavaString("Manage"), new JavaString("Rewards") };
        private Context context;

        public MainFragmentPagerAdapter(Android.Support.V4.App.FragmentManager fm, Context context) : base(fm)
        {
            this.context = context;
        }

        public override int Count
        {
            get
            {
                return PAGE_COUNT;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            if (position == 0)
            {
                return new OverviewFragment();
            }

            if (position == 1)
            {
                return new ManageFragment();
            }

            if (position == 2)
            {
                return new RewardsFragment();
            }
            throw new IndexOutOfRangeException();
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return tabTitles[position];
        }
    }
}