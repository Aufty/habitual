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
    public class MarkRoutineDoneInteractorImpl : AbstractInteractor, MarkRoutineDoneInteractor
    {
        private MarkRoutineDoneInteractorCallback callback;
        private RoutineRepository routineRepository;
        private UserRepository userRepository;
        private Routine routine;

        public MarkRoutineDoneInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        MarkRoutineDoneInteractorCallback callback, UserRepository userRepository,
                                        RoutineRepository routineRepository, Routine routine) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.routineRepository = routineRepository;
            this.userRepository = userRepository;
            this.routine = routine;
        }

        public override void Run()
        {
            var updatedRoutine = routineRepository.MarkDone(routine);
            if (updatedRoutine.Logs.Count <= routine.Logs.Count)
            {
                callback.OnError("Unable to mark routine done.");
                return;
            }
            var newPoints = userRepository.GetPoints(routine.Username);

            mainThread.Post(() => callback.OnRoutineMarkedDoneForToday(updatedRoutine, newPoints));
        }
    }
}
