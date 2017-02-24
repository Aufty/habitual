using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.UseCases.Base;
using Habitual.Core.Entities;

namespace Habitual.Core.UseCases
{
	public interface CreateTodoInteractorCallback
	{
        void OnTodoCreated(Todo todo);
	}
    public interface CreateTodoInteractor : Interactor
    {
    }
}
