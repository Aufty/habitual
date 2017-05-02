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
using Habitual.Core.Entities.Base;
using Habitual.Droid.UI;

namespace Habitual.Droid.Util
{
    public class ManageListAdapter : BaseAdapter<BaseTask>
    {
        private Activity context;
        private List<BaseTask> items;
        private MainApplicationCallback callback;

        public ManageListAdapter(Activity context, List<BaseTask> items, MainApplicationCallback callback)
        {
            this.context = context;
            this.items = items;
            this.callback = callback;
        }

        public override BaseTask this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            return GenerateItemViewBasedOnType(item, convertView, parent);
        }

        private View GenerateItemViewBasedOnType(BaseTask item, View convertView, ViewGroup parent)
        {
            var habit = item as Habit;
            var routine = item as Routine;
            var todo = item as Todo;

            if (convertView == null) // no view to re-use, create new
                convertView = context.LayoutInflater.Inflate(Resource.Layout.ManageCell, null);

            var view = GetGenericView(item, convertView);

            if (habit != null)
            {
                view.FindViewById<TextView>(Resource.Id.taskTypeManageText).Text = "HABIT";
            }

            else if (routine != null)
            {
                view.FindViewById<TextView>(Resource.Id.taskTypeManageText).Text = "ROUTINE";
            }

            else if (todo != null)
            {
                view.FindViewById<TextView>(Resource.Id.taskTypeManageText).Text = "TODO";
            }

            else
            {
                throw new InvalidCastException();
            }

            return view;
        }

        private View GetGenericView(BaseTask task, View view)
        {
            view.FindViewById<TextView>(Resource.Id.descriptionManageText).Text = $"{task.Description}";
            view.FindViewById<TextView>(Resource.Id.difficultyManageText).Text = $"{task.Difficulty}";
            view.FindViewById<TextView>(Resource.Id.routineManageText).Visibility = ViewStates.Gone;

            return view;
        }

        private View GenerateTodoCell(Todo todo, View view)
        {
            return view;
        }

        private View GenerateRoutineCell(Routine routine, View view)
        {
            return view;
        }

        private View GenerateHabitCell(Habit habit, View view)
        {
            return view;
        }

        public void Update(List<BaseTask> items)
        {
            if (items != null)
            {
                this.items = items;
                context.RunOnUiThread(() => NotifyDataSetChanged());
            }
            callback.UserUpdateRequested();
        }
    }
}
