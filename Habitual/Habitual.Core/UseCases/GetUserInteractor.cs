﻿using Habitual.Core.Entities;
using Habitual.Core.UseCases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.UseCases
{
    public interface GetUserInteractorCallback : InteractorCallback
    {
        void OnUserRetrieved(User user);
    }

    public interface GetUserInteractor : Interactor
    {

    }
}