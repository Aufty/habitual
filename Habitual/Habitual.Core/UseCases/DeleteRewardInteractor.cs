﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.UseCases.Base;

namespace Habitual.Core.UseCases
{
	public interface DeleteRewardInteractorCallback : InteractorCallback
	{
        void OnRewardDeleted(Guid rewardID);
	}
    public interface DeleteRewardInteractor : Interactor
    {
    }
}
