using Habitual.Core.Entities;
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
    public class UpdateTodoInteractorImpl : AbstractInteractor, UpdateTodoInteractor
    {
        private UpdateTodoInteractorCallback callback;
        private TodoRepository todoRepository;
        private Todo todo;

        public UpdateTodoInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        UpdateTodoInteractorCallback callback, TodoRepository todoRepository,
                                        Todo todo) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.todoRepository = todoRepository;
            this.todo = todo;
        }

        public override void Run()
        {
            //todoRepository.Update(todo);
            //mainThread.Post(() => callback.OnTodoUpdated(todo));
        }
    }
}
