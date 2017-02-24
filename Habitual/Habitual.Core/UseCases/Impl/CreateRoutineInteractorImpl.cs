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
    public class CreateRoutineInteractorImpl : AbstractInteractor, CreateRoutineInteractor
    {
        private CreateRoutineInteractorCallback callback;
        private RoutineRepository routineRepository;

        private string description;
        private User user;
        private Difficulty difficulty;

        public CreateRoutineInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        CreateRoutineInteractorCallback callback, RoutineRepository routineRepository, User user,
                                        string description, Difficulty difficulty) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.routineRepository = routineRepository;
            this.description = description;
            this.difficulty = difficulty;
            this.user = user;
        }

        public override void Run()
        {
            var routine = new Routine();
            routine.Description = description;
            routine.Difficulty = difficulty;
            routine.UserID = user.ID;
            routineRepository.Create(routine);

            mainThread.Post(() => callback.OnRoutineCreated(routine));
        }
    }
}
