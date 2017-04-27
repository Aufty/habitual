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
    public class OverviewListAdapter : BaseAdapter<BaseTask>
    {
        private Activity context;
        private List<BaseTask> items;
        private List<HabitLog> habitLogs;
        private List<RoutineLog> routineLogs;
        private MainApplicationCallback callback;

        public OverviewListAdapter(Activity context, List<BaseTask> items, MainApplicationCallback callback)
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
                convertView = context.LayoutInflater.Inflate(Resource.Layout.TaskCell, null);

            var view = GetGenericView(item, convertView);

            if (habit != null)
            {
                return GenerateHabitCell(habit, view);
            }

            else if (routine != null)
            {
                return GenerateRoutineCell(routine, view);
            }

            else if (todo != null)
            {
                return GenerateTodoCell(todo, view);
            }

            else
            {
                throw new InvalidCastException();
            }
        }

        private View GenerateTodoCell(Todo todo, View view)
        {
            var checkBox = view.FindViewById<CheckBox>(Resource.Id.markDoneCheckbox);
            checkBox.Visibility = ViewStates.Visible;
            checkBox.Checked = todo.IsDone;

            var image = view.FindViewById<ImageView>(Resource.Id.taskIcon);
            image.SetImageResource(Resource.Drawable.todo);

            return view;
        }

        private View GenerateRoutineCell(Routine routine, View view)
        {
            var checkBox = view.FindViewById<CheckBox>(Resource.Id.markDoneCheckbox); // TODO: Check if habit is finished
            checkBox.Visibility = ViewStates.Visible;
            

            var image = view.FindViewById<ImageView>(Resource.Id.taskIcon);
            image.SetImageResource(Resource.Drawable.routine);

            if (routineLogs != null)
            {
                var logs = routineLogs.Where(r => r.RoutineID == routine.ID);
                checkBox.Checked = WasTodayLogged(routine, logs);
            }

            return view;
        }

        private bool WasTodayLogged(Routine routine, IEnumerable<RoutineLog> logs)
        {
            var today = DateTime.UtcNow.Date;
            foreach (RoutineLog log in logs)
            {
                if (routine.ID == log.RoutineID && log.TimestampUTC.Date == today)
                {
                    return true;
                }
            }
            return false;
        }

        private View GenerateHabitCell(Habit habit, View view)
        { 
            var habitCount = view.FindViewById<TextView>(Resource.Id.habitCount);
            habitCount.Visibility = ViewStates.Visible;
            habitCount.Text = GetHabitCount(habit);

            var image = view.FindViewById<ImageView>(Resource.Id.taskIcon);
            image.SetImageResource(Resource.Drawable.habit);

            return view;
        }

        private View GetGenericView(BaseTask task, View view)
        {
            view.FindViewById<TextView>(Resource.Id.taskDescription).Text = string.Format("{0}", task.Description);

            var checkBox = view.FindViewById<CheckBox>(Resource.Id.markDoneCheckbox);
            var habitCount = view.FindViewById<TextView>(Resource.Id.habitCount);

            checkBox.Visibility = ViewStates.Gone;
            checkBox.Checked = false;
            checkBox.Focusable = false;
            checkBox.FocusableInTouchMode = false;
            checkBox.Clickable = false;
            habitCount.Visibility = ViewStates.Gone;

            return view;
        }

        private string GetHabitCount(Habit habit)
        {
            if (habit == null || habitLogs == null)
            {
                return 0.ToString();
            }
            var logs = habitLogs.Where(h => h.HabitID == habit.ID);
            return logs.ToList().Count.ToString();
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


        public void UpdateLogs(List<HabitLog> habitLogs, List<RoutineLog> routineLogs)
        {
            this.habitLogs = habitLogs;
            this.routineLogs = routineLogs;
        }
    }
}