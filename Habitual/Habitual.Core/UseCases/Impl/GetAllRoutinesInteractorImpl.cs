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
    public class GetAllRoutinesInteractorImpl : AbstractInteractor, GetAllRoutinesInteractor
    {
        private GetAllRoutinesInteractorCallback callback;
        private RoutineRepository routineRepository;
        private User user;

        public GetAllRoutinesInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        GetAllRoutinesInteractorCallback callback, RoutineRepository routineRepository,
                                        User user) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.routineRepository = routineRepository;
            this.user = user;
        }

        public override void Run()
        {
            var routines = routineRepository.GetAllForUser(user.Username);
            mainThread.Post(() => callback.OnRoutinesRetrieved(routines));
        }
    }
}
