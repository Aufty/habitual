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
    public class DeleteRoutineInteractorImpl : AbstractInteractor, DeleteRoutineInteractor
    {
        private DeleteRoutineInteractorCallback callback;
        private RoutineRepository routineRepository;

        private int routineID;

        public DeleteRoutineInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        DeleteRoutineInteractorCallback callback, RoutineRepository routineRepository, int RoutineID) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.routineRepository = routineRepository;
            this.routineID = RoutineID;
        }

        public override void Run()
        {
            routineRepository.Delete(routineID);

            mainThread.Post(() => callback.OnRoutineDeleted(routineID));
        }
    }
}
