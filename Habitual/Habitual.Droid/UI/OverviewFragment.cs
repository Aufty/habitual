using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using Habitual.Core.Entities;
using Habitual.Core.Entities.Base;
using Habitual.Core.Executors;
using Habitual.Core.Executors.Impl;
using Habitual.Droid.Presenters;
using Habitual.Droid.Presenters.Impl;
using Habitual.Droid.Threading;
using Habitual.Droid.Util;
using Habitual.Storage;
using Habitual.Storage.Local;

namespace Habitual.Droid.UI
{
    public class OverviewFragment : Android.Support.V4.App.Fragment, OverviewView
    {
        private ListView overviewList;
        private List<BaseTask> items;
        private List<HabitLog> habitLogs;
        private List<RoutineLog> routineLogs;
        private OverviewListAdapter adapter;
        private OverviewPresenter presenter;
        private MainThread mainThread;
        private MainApplicationCallback callback;

        public OverviewFragment(MainApplicationCallback callback)
        {
            this.callback = callback;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Init();
        }

        private void Init()
        {
            mainThread = new MainThreadImpl(this.Activity);
            presenter = new OverviewPresenterImpl(TaskExecutor.GetInstance(), mainThread, this, new HabitRepositoryImpl(), new RoutineRepositoryImpl(), new TodoRepositoryImpl(), new UserRepositoryImpl(), LocalData.Username, LocalData.Password);
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
            adapter = new OverviewListAdapter(Activity, items, callback);
            overviewList.ItemClick += TaskClicked;
            overviewList.Adapter = adapter;
            Update();
        }

        private void TaskClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = items[e.Position];
            var habit = item as Habit;
            var routine = item as Routine;
            var todo = item as Todo;
            if (habit != null)
            {
                presenter.MarkHabitDone(habit);
            }
            if (routine != null)
            {
                presenter.MarkRoutineDone(routine);
            }
            if (todo != null)
            {
                presenter.MarkTodoDone(todo);
            }
        }

        public void Update()
        {
            presenter.GetTasks(LocalData.Username, LocalData.Password);
        }

        public void UpdateTasks(List<BaseTask> tasks)
        {
            this.items = tasks;
            adapter.Update(items);
        }

        public void OnTasksRetrieved(TaskContainer tasks)
        {
            try
            {
                items.Clear();
                items.AddRange(tasks.Habits);
                items.AddRange(tasks.Routines);
                items.AddRange(tasks.Todos);

                habitLogs = tasks.HabitLogs;
                routineLogs = tasks.RoutineLogs;

                adapter.UpdateLogs(habitLogs, routineLogs);
                UpdateTasks(items);
            }
            catch (Exception ex) { }
        }

        public void ShowProgress()
        {
            throw new NotImplementedException();
        }

        public void HideProgress()
        {
            throw new NotImplementedException();
        }

        public void ShowError()
        {
            throw new NotImplementedException();
        }

        public void OnHabitMarkedDone(int pointsAdded)
        {
            NotifyPoints(pointsAdded);
            Update();
        }

        public void OnRoutineMarkedDone(int pointsAdded)
        {
            NotifyPoints(pointsAdded);
            Update();
        }

        private void NotifyPoints(int pointsAdded)
        {
            Toast.MakeText(Activity, string.Format("{0} points earned!", pointsAdded), ToastLength.Short).Show();
        }

        public void OnTodoMarkedDone(int pointsAdded)
        {
            NotifyPoints(pointsAdded);
            Update();
        }

    }

   
}