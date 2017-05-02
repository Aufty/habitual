using Habitual.Core.Executors;
using Habitual.Core.Repositories;
using Habitual.Core.UseCases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.Entities;

namespace Habitual.Core.UseCases.Impl
{
    public class DeleteTodoInteractorImpl : AbstractInteractor, DeleteTodoInteractor
    {
        private DeleteTodoInteractorCallback callback;
        private TodoRepository todoRepository;

        private Todo todo;

        public DeleteTodoInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        DeleteTodoInteractorCallback callback, TodoRepository TodoRepository, Todo todo) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.todoRepository = TodoRepository;
            this.todo = todo;
        }

        public override void Run()
        {
            todoRepository.Delete(todo.ID);

            mainThread.Post(() => callback.OnTodoDeleted(todo.ID));
        }
    }
}
