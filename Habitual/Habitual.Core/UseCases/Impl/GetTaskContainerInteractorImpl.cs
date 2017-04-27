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

        public GetTaskContainerInteractorImpl(Executor taskExecutor, MainThread mainThread, GetTaskContainerCallback callback, HabitRepository habitRepository, RoutineRepository routineRepository, TodoRepository todoRepository, string username, string password) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.habitRepository = habitRepository;
            this.routineRepository = routineRepository;
            this.todoRepository = todoRepository;
            this.username = username;
            this.password = password;
            this.date = DateTime.UtcNow;
        }

        public override void Run()
        {
            var newTaskContainer = new TaskContainer();
            newTaskContainer.Habits = habitRepository.GetAllForUser(username);
            newTaskContainer.Routines = routineRepository.GetAllForUser(username);
            newTaskContainer.Todos = todoRepository.GetAllForUser(username);
            newTaskContainer.HabitLogs = habitRepository.GetLogs(date, username);
            newTaskContainer.RoutineLogs = routineRepository.GetLogs(date, username);

            mainThread.Post(() => { callback.OnTaskContainerFilled(newTaskContainer); });
        }
    }
}
