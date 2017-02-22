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
    public class GetAllHabitsInteractorImpl : AbstractInteractor, GetAllHabitsInteractor
    {
        private GetAllHabitsInteractorCallback callback;
        private HabitRepository habitRepository;
        private User user;

        public GetAllHabitsInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        GetAllHabitsInteractorCallback callback, HabitRepository habitRepository,
                                        User user) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.habitRepository = habitRepository;
            this.user = user;
        }

        public override void Run()
        {
            var habits = habitRepository.GetAllHabitsForUser(user.Username);
            mainThread.Post(() => callback.OnAllHabitsRetrieved(habits));
        }
    }
}
