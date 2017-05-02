﻿using Habitual.Core.Executors;
using Habitual.Core.Repositories;
using Habitual.Core.UseCases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.Entities;

namespace Habitual.Core.UseCases.Impl
{
    public class DeleteRoutineInteractorImpl : AbstractInteractor, DeleteRoutineInteractor
    {
        private DeleteRoutineInteractorCallback callback;
        private RoutineRepository routineRepository;

        private Routine routine;

        public DeleteRoutineInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        DeleteRoutineInteractorCallback callback, RoutineRepository routineRepository, Routine routine) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.routineRepository = routineRepository;
            this.routine = routine;
        }

        public override void Run()
        {
            routineRepository.Delete(routine.ID);

            mainThread.Post(() => callback.OnRoutineDeleted(routine.ID));
        }
    }
}
