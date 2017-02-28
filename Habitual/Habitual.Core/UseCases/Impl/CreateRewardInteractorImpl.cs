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

        private string description;
        private User user;
        private int cost;

        public CreateRewardInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        CreateRewardInteractorCallback callback, RewardRepository rewardRepository, User user,
                                        string description, int cost) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.rewardRepository = rewardRepository;
            this.description = description;
            this.cost = cost;
            this.user = user;
        }

        public override void Run()
        {
            var reward = new Reward();
            reward.Description = description;
            reward.Cost = cost;
            reward.Username = user.Username;
            rewardRepository.Create(reward);

            mainThread.Post(() => callback.OnRewardCreated(reward));
        }
    }
}
