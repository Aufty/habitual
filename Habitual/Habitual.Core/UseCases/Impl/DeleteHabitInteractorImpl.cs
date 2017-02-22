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
    public class DeleteHabitInteractorImpl : AbstractInteractor, DeleteHabitInteractor
    {
        private DeleteHabitInteractorCallback callback;
        private HabitRepository habitRepository;

        private int habitID;

        public DeleteHabitInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        DeleteHabitInteractorCallback callback, HabitRepository habitRepository, int habitID) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.habitRepository = habitRepository;
            this.habitID = habitID;
        }

        public override void Run()
        {
            habitRepository.Delete(habitID);

            mainThread.Post(() => callback.OnHabitDeleted(habitID));
        }
    }
}
