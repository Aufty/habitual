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
    public class DeleteRewardInteractorImpl : AbstractInteractor, DeleteRewardInteractor
    {
        private DeleteRewardInteractorCallback callback;
        private RewardRepository rewardRepository;

        private int rewardID;

        public DeleteRewardInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        DeleteRewardInteractorCallback callback, RewardRepository rewardRepository, int RewardID) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.rewardRepository = rewardRepository;
            this.rewardID = RewardID;
        }

        public override void Run()
        {
            rewardRepository.Delete(rewardID);

            mainThread.Post(() => callback.OnRewardDeleted(rewardID));
        }
    }
}
