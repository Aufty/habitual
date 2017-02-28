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
    public class IncrementHabitInteractorImpl : AbstractInteractor, IncrementHabitInteractor
    {
        private IncrementHabitInteractorCallback callback;
        private HabitRepository habitRepository;
        private UserRepository userRepository;
        private Habit habit;

        public IncrementHabitInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        IncrementHabitInteractorCallback callback, HabitRepository habitRepository,
                                        UserRepository userRepository, Habit habit) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.habitRepository = habitRepository;
            this.userRepository = userRepository;
            this.habit = habit;
        }

        public override void Run()
        {
            var newCount = habitRepository.IncrementHabit(habit);
            var newPoints = userRepository.GetPoints(habit.Username);

            mainThread.Post(() => callback.OnHabitIncremented(newCount, newPoints));
        }
    }
}
