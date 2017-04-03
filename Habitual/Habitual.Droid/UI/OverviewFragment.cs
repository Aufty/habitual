using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Habitual.Core.Entities.Base;
using Habitual.Core.Entities;
using Android.App;

namespace Habitual.Droid.UI
{
    public class OverviewFragment : Android.Support.V4.App.Fragment
    {
        private ListView overviewList;
        private List<BaseTask> items;
        private OverviewListAdapter adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            
            var view = inflater.Inflate(Resource.Layout.Overview, container, false);
            InitializeElements(view);
            return view;
        }

        private void InitializeElements(View view)
        {
            if (items == null) items = new List<BaseTask>();
            overviewList = view.FindViewById<ListView>(Resource.Id.overviewList);
            adapter = new OverviewListAdapter(Activity, items);
            overviewList.Adapter = adapter;
            /**************************************
             * TEST CODE - Remove once actual logic in place
             **************************************/
            var habit = new Habit();
            habit.Description = "Test Habit";
            items.Add(habit);
            adapter.Update(items);
            /**************************************/
        }
    }

    public class OverviewListAdapter : BaseAdapter<BaseTask>
    {
        private Activity context;
        private List<BaseTask> items;

        public OverviewListAdapter(Activity context, List<BaseTask> items)
        {
            this.context = context;
            this.items = items;
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

            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.TaskCell, null);

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
            throw new NotImplementedException();
        }

        private View GenerateRoutineCell(Routine routine, View view)
        {
            throw new NotImplementedException();
        }

        private View GenerateHabitCell(Habit habit, View view)
        {
            view.FindViewById<TextView>(Resource.Id.taskDescription).Text = string.Format("{0}", habit.Description);
            view.FindViewById<CheckBox>(Resource.Id.markDoneCheckbox).Checked = true; // TODO: Check if habit is finished
            var image = view.FindViewById<ImageView>(Resource.Id.taskIcon);
            image.SetImageResource(Resource.Drawable.habit);

            return view;
        }

        public void Update(List<BaseTask> items)
        {
            if (items != null)
            {
                this.items = items;
                context.RunOnUiThread(() => NotifyDataSetChanged());
            }
        }
    }
}