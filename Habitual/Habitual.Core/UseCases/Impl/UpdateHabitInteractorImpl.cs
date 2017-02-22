using Habitual.Core.Entities;
using Habitual.Core.Executors;
using Habitual.Core.Repositories;
using Habitual.Core.UseCases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.UseCases.Impl
{
    public class UpdateHabitInteractorImpl : AbstractInteractor, UpdateHabitInteractor
    {
        private UpdateHabitInteractorCallback callback;
        private HabitRepository habitRepository;
        private Habit habit;

        public UpdateHabitInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        UpdateHabitInteractorCallback callback, HabitRepository habitRepository,
                                        Habit habit) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.habitRepository = habitRepository;
            this.habit = habit;
        }

        public override void Run()
        {
            habitRepository.Update(habit);
            mainThread.Post(() => callback.OnHabitUpdated(habit));
        }
    }
}
