using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.Entities;
using Habitual.Core.Executors;
using Habitual.Core.Repositories;
using Habitual.Core.UseCases.Base;

namespace Habitual.Core.UseCases.Impl
{
    public class GetTaskContainerInteractorImpl : AbstractInteractor, GetTaskContainerInteractor
    {
        private GetTaskContainerCallback callback;
        private HabitRepository habitRepository;
        private RoutineRepository routineRepository;
        private TodoRepository todoRepository;
        private DateTime date;
        private string username;
        private string password;
        private DayOfWeek dayOfWeek;
        private bool includeAllRoutines;
        private bool includeLogs;

        public GetTaskContainerInteractorImpl(Executor taskExecutor, MainThread mainThread, GetTaskContainerCallback callback, HabitRepository habitRepository, RoutineRepository routineRepository, TodoRepository todoRepository, string username, string password, DayOfWeek dayOfWeek, bool includeAllRoutines = false, bool includeLogs = false) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.habitRepository = habitRepository;
            this.routineRepository = routineRepository;
            this.todoRepository = todoRepository;
            this.username = username;
            this.password = password;
            this.dayOfWeek = dayOfWeek;
            this.includeAllRoutines = includeAllRoutines;
            this.includeLogs = includeLogs;
        }

        public async override void Run()
        {
            var newTaskContainer = TaskContainer.GetTaskContainer();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                callback.OnTaskContainerFilled(newTaskContainer);
                return;
            }
            
            //newTaskContainer.HabitLogs = new List<HabitLog>();
            newTaskContainer.Habits = await habitRepository.GetAll(username);
            //newTaskContainer.Routines = includeAllRoutines ? routineRepository.GetAllRoutinesIncludingOtherDays(username) : routineRepository.GetAllForUser(username, dayOfWeek);
            //newTaskContainer.Todos = todoRepository.GetAllForUser(username);
            if (includeLogs)
            {
                if (newTaskContainer.Habits != null && newTaskContainer.Habits.Count > 0) newTaskContainer.HabitLogs = await habitRepository.GetLogs(DateTime.Today, username);
                //newTaskContainer.RoutineLogs = routineRepository.GetLogs(date, username);
            }

            mainThread.Post(() => { callback.OnTaskContainerFilled(newTaskContainer); });
        }
    }
}
