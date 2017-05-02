using Habitual.Core.Executors;
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
    public class DeleteRewardInteractorImpl : AbstractInteractor, DeleteRewardInteractor
    {
        private DeleteRewardInteractorCallback callback;
        private RewardRepository rewardRepository;

        private Reward reward;

        public DeleteRewardInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        DeleteRewardInteractorCallback callback, RewardRepository rewardRepository, Reward reward) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.rewardRepository = rewardRepository;
            this.reward = reward;
        }

        public override void Run()
        {
            rewardRepository.Delete(reward.ID);

            mainThread.Post(() => callback.OnRewardDeleted(reward.ID));
        }
    }
}
