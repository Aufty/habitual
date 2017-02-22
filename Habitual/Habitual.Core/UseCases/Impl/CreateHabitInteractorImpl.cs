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
    public class CreateHabitInteractorImpl : AbstractInteractor, CreateHabitInteractor
    {
        private CreateHabitInteractorCallback callback;
        private HabitRepository habitRepository;

        private string description;
        private User user;
        private Difficulty difficulty;

        public CreateHabitInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        CreateHabitInteractorCallback callback, HabitRepository habitRepository, User user,
                                        string description, Difficulty difficulty) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.habitRepository = habitRepository;
            this.description = description;
            this.difficulty = difficulty;
            this.user = user;
        }

        public override void Run()
        {
            var habit = new Habit();
            habit.Description = description;
            habit.Difficulty = difficulty;
            habit.UserID = user.ID;
            habitRepository.Create(habit);

            mainThread.Post(() => callback.OnHabitCreated(habit));
        }
    }
}
