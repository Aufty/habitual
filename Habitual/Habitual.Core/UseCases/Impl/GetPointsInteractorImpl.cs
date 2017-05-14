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
    public class GetPointsInteractorImpl : AbstractInteractor, GetPointsInteractor
    {
        private GetPointsInteractorCallback callback;
        private UserRepository userRepository;

        string username;
        string password;

        public GetPointsInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        GetPointsInteractorCallback callback, UserRepository userRepository,
                                        string username, string password) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.userRepository = userRepository;
            this.username = username;
            this.password = password;
        }

        public override void Run()
        {
            try
            {
                var points = userRepository.GetPoints(username);

                mainThread.Post(() => callback.OnPointsRetrieved(points));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
