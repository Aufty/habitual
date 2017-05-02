﻿using Habitual.Core.Entities;
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
    public class BuyRewardInteractorImpl : AbstractInteractor, BuyRewardInteractor
    {
        private BuyRewardInteractorCallback callback;
        private RewardRepository rewardRepository;
        private UserRepository userRepository;
        private Reward reward;

        public BuyRewardInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        BuyRewardInteractorCallback callback, RewardRepository rewardRepository,
                                        UserRepository userRepository, Reward reward) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.rewardRepository = rewardRepository;
            this.userRepository = userRepository;
            this.reward = reward;
        }

        public override void Run()
        {
            var result = userRepository.BuyReward(reward);

            if (result)
            {
                mainThread.Post(() => callback.OnRewardPurchased(reward, 0));
            } else
            {
                mainThread.Post(() => callback.OnError("Not enough points to purchase this reward."));
            }
            
        }
    }
}
