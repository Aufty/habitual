using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.UseCases.Base;
using Habitual.Core.Entities;

namespace Habitual.Core.UseCases
{
	public interface GetAllRewardsInteractorCallback : InteractorCallback
	{
        void OnRewardsRetrieved(List<Reward> rewards);
	}
    public interface GetAllRewardsInteractor : Interactor
    {
    }
}
