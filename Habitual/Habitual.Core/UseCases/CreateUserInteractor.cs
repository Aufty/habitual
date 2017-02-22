﻿using Habitual.Core.Entities;
using Habitual.Core.UseCases.Base;

namespace Habitual.Core.UseCases
{
    public interface CreateUserInteractorCallback : InteractorCallback
    {
        void OnUserCreated();
    }
    public interface CreateUserInteractor : Interactor
    {
    }
}