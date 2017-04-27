using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.Entities;
using Habitual.Core.UseCases.Base;

namespace Habitual.Core.UseCases
{
    public interface GetTaskContainerCallback : InteractorCallback
    {
        void OnTaskContainerFilled(TaskContainer taskContainer);
    }
    public interface GetTaskContainerInteractor : Interactor
    {
    }
}
