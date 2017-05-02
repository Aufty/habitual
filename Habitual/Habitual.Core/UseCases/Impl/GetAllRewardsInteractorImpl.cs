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
    public class GetAllRewardsInteractorImpl : AbstractInteractor, GetAllRewardsInteractor
    {
        private GetAllRewardsInteractorCallback callback;
        private RewardRepository rewardRepository;
        private string username;

        public GetAllRewardsInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        GetAllRewardsInteractorCallback callback, RewardRepository rewardRepository,
                                        string username) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.rewardRepository = rewardRepository;
            this.username = username;
        }

        public override void Run()
        {
            var rewards = rewardRepository.GetAllForUser(username);
            mainThread.Post(() => callback.OnRewardsRetrieved(rewards));
        }
    }
}
