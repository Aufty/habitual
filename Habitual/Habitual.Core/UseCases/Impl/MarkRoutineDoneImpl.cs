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
        private DateTime utcTimeStamp;
        private Routine routine;

        public MarkRoutineDoneInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        MarkRoutineDoneInteractorCallback callback, RoutineRepository routineRepository,
                                        UserRepository userRepository, Routine routine, DateTime utcTimeStamp) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.routineRepository = routineRepository;
            this.userRepository = userRepository;
            this.routine = routine;
            this.utcTimeStamp = utcTimeStamp;
        }

        public override void Run()
        {
            var updatedRoutine = routineRepository.MarkDone(routine, utcTimeStamp);
            //if (updatedRoutine.Logs.Count <= routine.Logs.Count)
            //{
            //    callback.OnError("Unable to mark routine done.");
            //    return;
            //}
            var pointsAdded = 0;
            if (routine.Difficulty == Difficulty.Easy) pointsAdded = 10;
            if (routine.Difficulty == Difficulty.Medium) pointsAdded = 20;
            if (routine.Difficulty == Difficulty.Hard) pointsAdded = 30;
            if (routine.Difficulty == Difficulty.VeryHard) pointsAdded = 40;
            userRepository.IncrementPoints(routine.Username, pointsAdded);

            mainThread.Post(() => callback.OnRoutineMarkedDoneForToday(pointsAdded));
        }
    }
}
