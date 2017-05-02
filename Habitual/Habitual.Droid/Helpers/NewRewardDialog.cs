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
using Habitual.Core.Entities;

namespace Habitual.Droid.Helpers
{
    public static class NewRewardDialog
    {
        public static Reward GenerateRewardFromDialog(View view)
        {
            var reward = new Reward();
            reward.Description = view.FindViewById<EditText>(Resource.Id.descriptionNewRewardEntry).Text;
            reward.Cost = int.Parse(view.FindViewById<EditText>(Resource.Id.costNewRewardEntry).Text);

            return reward;
        }
    }
}