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
    public class CreateTodoInteractorImpl : AbstractInteractor, CreateTodoInteractor
    {
        private CreateTodoInteractorCallback callback;
        private TodoRepository TodoRepository;

        private string description;
        private User user;
        private Difficulty difficulty;

        public CreateTodoInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        CreateTodoInteractorCallback callback, TodoRepository TodoRepository, User user,
                                        string description, Difficulty difficulty) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.TodoRepository = TodoRepository;
            this.description = description;
            this.difficulty = difficulty;
            this.user = user;
        }

        public override void Run()
        {
            var todo = new Todo();
            todo.Description = description;
            todo.Difficulty = difficulty;
            todo.Username = user.Username;
            TodoRepository.Create(todo);

            mainThread.Post(() => callback.OnTodoCreated(todo));
        }
    }
}
