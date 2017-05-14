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
    public class UpdateRoutineInteractorImpl : AbstractInteractor, UpdateRoutineInteractor
    {
        private UpdateRoutineInteractorCallback callback;
        private RoutineRepository routineRepository;
        private Routine rotuine;

        public UpdateRoutineInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        UpdateRoutineInteractorCallback callback, RoutineRepository routineRepository,
                                        Routine routine) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.routineRepository = routineRepository;
            this.rotuine = routine;
        }

        public override void Run()
        {
            //routineRepository.Update(rotuine);
            //mainThread.Post(() => callback.OnRoutineUpdated(rotuine));
        }
    }
}
