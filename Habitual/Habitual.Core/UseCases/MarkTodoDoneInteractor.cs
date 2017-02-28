using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.UseCases.Base;
using Habitual.Core.Entities;

namespace Habitual.Core.UseCases
{
	public interface MarkTodoDoneInteractorCallback : InteractorCallback
	{
        void OnTodoMarkedDone(Todo todo, int newPoints);
	}
    public interface MarkTodoDoneInteractor : Interactor
    {
    }
}
