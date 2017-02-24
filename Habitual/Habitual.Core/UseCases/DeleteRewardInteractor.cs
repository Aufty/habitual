using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.UseCases.Base;

namespace Habitual.Core.UseCases
{
	public interface DeleteRewardInteractorCallback
	{
        void OnRewardDeleted(int rewardID);
	}
    public interface DeleteRewardInteractor : Interactor
    {
    }
}
