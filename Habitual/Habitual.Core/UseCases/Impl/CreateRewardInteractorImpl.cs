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
    public class CreateRewardInteractorImpl : AbstractInteractor, CreateRewardInteractor
    {
        private CreateRewardInteractorCallback callback;
        private RewardRepository rewardRepository;
        private string username;
        private Reward reward;

        public CreateRewardInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        CreateRewardInteractorCallback callback, RewardRepository rewardRepository, Reward reward) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.rewardRepository = rewardRepository;
            this.reward = reward;
        }

        public override void Run()
        {
            try
            {
                reward.ID = Guid.NewGuid();
                reward.Username = username;
                rewardRepository.Create(reward);

                mainThread.Post(() => callback.OnRewardCreated(reward));
            }
            catch (Exception)
            {
                mainThread.Post(() => callback.OnError("Error creating  reward. Try again."));
            }
        }
    }
}
