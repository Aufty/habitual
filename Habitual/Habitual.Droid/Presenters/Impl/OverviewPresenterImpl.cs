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
using Habitual.Core.Executors;
using Habitual.Core.Repositories;
using Habitual.Core.UseCases;
using Habitual.Core.UseCases.Impl;

namespace Habitual.Droid.Presenters.Impl
{
    public class OverviewPresenterImpl : AbstractPresenter, OverviewPresenter, GetTaskContainerCallback, IncrementHabitInteractorCallback, MarkRoutineDoneInteractorCallback, MarkTodoDoneInteractorCallback
    {
        private OverviewView view;
        private HabitRepository habitRepository;
        private RoutineRepository routineRepository;
        private TodoRepository todoRepository;
        private UserRepository userRepository;
        private string username;
        private string password;

        public OverviewPresenterImpl(Executor executor, MainThread mainThread, OverviewView view, HabitRepository habitRepository, RoutineRepository routineRepository, TodoRepository todoRepository, UserRepository userRepository, string username, string password) : base(executor, mainThread)
        {
            this.view = view;
            this.habitRepository = habitRepository;
            this.userRepository = userRepository;
            this.routineRepository = routineRepository;
            this.todoRepository = todoRepository;
            this.username = username;
            this.password = password;
        }

        public void GetTasks(string username, string password)
        {
            GetTaskContainerInteractor getTaskInteractor = new GetTaskContainerInteractorImpl(executor, mainThread, this, habitRepository, routineRepository, todoRepository, username, password);
            getTaskInteractor.Execute();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }

        public void OnError(string message)
        {
            throw new NotImplementedException();
        }

        public void OnTaskContainerFilled(TaskContainer taskContainer)
        {
            view.OnTasksRetrieved(taskContainer);
        }

        public void MarkHabitDone(Habit habit)
        {
            IncrementHabitInteractor interactor = new IncrementHabitInteractorImpl(executor, mainThread, this, habitRepository, userRepository, habit);
            interactor.Execute();
        }

        public void OnHabitIncremented(int pointsAdded)
        {
            view.OnHabitMarkedDone(pointsAdded);
        }

        public void MarkRoutineDone(Routine routine)
        {
            MarkRoutineDoneInteractor interactor = new MarkRoutineDoneInteractorImpl(executor, mainThread, this, routineRepository, userRepository, routine, DateTime.UtcNow);
            interactor.Execute();
        }

        public void OnRoutineMarkedDoneForToday(int pointsAdded)
        {
            view.OnRoutineMarkedDone(pointsAdded);
        }

        public void MarkTodoDone(Todo todo)
        {
            MarkTodoDoneInteractor interactor = new MarkTodoDoneInteractorImpl(executor, mainThread, this, todoRepository, userRepository, todo);
            interactor.Execute();
        }

        public void OnTodoMarkedDone(int pointsAdded)
        {
            view.OnTodoMarkedDone(pointsAdded);
        }
    }
}