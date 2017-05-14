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
using Habitual.Core.Entities.Base;

namespace Habitual.Droid.UI.ViewModels
{
    public class OverviewItem
    {
        public OverviewItem(BaseTask task)
        {
            Task = task;
        }
        public BaseTask Task { get; set; }
        public bool IsUntouchable { get; set; }
    }

    public class OverviewItemList : List<OverviewItem>
    {
        public void AddTasks(List<BaseTask> tasks)
        {
            foreach (BaseTask task in tasks)
            {
                Add(new OverviewItem(task));
            }
        }
    }
}