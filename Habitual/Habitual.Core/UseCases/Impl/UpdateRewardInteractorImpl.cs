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
    public class UpdateRewardInteractorImpl : AbstractInteractor, UpdateRewardInteractor
    {
        private UpdateRewardInteractorCallback callback;
        private RewardRepository rewardRepository;
        private Reward reward;

        public UpdateRewardInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        UpdateRewardInteractorCallback callback, RewardRepository rewardRepository,
                                        Reward reward) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.rewardRepository = rewardRepository;
            this.reward = reward;
        }

        public override void Run()
        {
            rewardRepository.Update(reward);
            mainThread.Post(() => callback.OnRewardUpdated(reward));
        }
    }
}
