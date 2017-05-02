using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.UseCases.Base;

namespace Habitual.Core.UseCases
{
	public interface DeleteTodoInteractorCallback : InteractorCallback
	{
        void OnTodoDeleted(Guid id);
	}
    public interface DeleteTodoInteractor : Interactor
    {
    }
}

