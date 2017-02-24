using Habitual.Core.Executors;
using Habitual.Core.Repositories;
using Habitual.Core.UseCases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.UseCases.Impl
{
    public class DeleteTodoInteractorImpl : AbstractInteractor, DeleteTodoInteractor
    {
        private DeleteTodoInteractorCallback callback;
        private TodoRepository todoRepository;

        private int todoID;

        public DeleteTodoInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        DeleteTodoInteractorCallback callback, TodoRepository TodoRepository, int TodoID) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.todoRepository = TodoRepository;
            this.todoID = TodoID;
        }

        public override void Run()
        {
            todoRepository.Delete(todoID);

            mainThread.Post(() => callback.OnTodoDeleted(todoID));
        }
    }
}
