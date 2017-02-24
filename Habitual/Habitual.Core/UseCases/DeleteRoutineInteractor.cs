﻿using Habitual.Core.UseCases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.UseCases
{
    public interface DeleteRoutineInteractorCallback
    {
        void OnRoutineDeleted(int routineID);
    }
    public interface DeleteRoutineInteractor : Interactor
    {
    }
}