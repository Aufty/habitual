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
    public class MarkTodoDoneInteractorImpl : AbstractInteractor, MarkTodoDoneInteractor
    {
        private MarkTodoDoneInteractorCallback callback;
        private TodoRepository todoRepository;
        private UserRepository userRepository;
        private Todo todo;

        public MarkTodoDoneInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        MarkTodoDoneInteractorCallback callback, TodoRepository todoRepository,
                                        UserRepository userRepository, Todo todo) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.todoRepository = todoRepository;
            this.userRepository = userRepository;
            this.todo = todo;
        }

        public override void Run()
        {
            if (todo.IsDone)
            {
                callback.OnError("This todo is already marked done.");
                return;
            }

            var doneTodo = todoRepository.MarkDone(todo);

            if (!doneTodo.IsDone)
            {
                callback.OnError("Todo was not marked done. Try again");
                return;
            }

            var pointsAdded = 0;
            if (doneTodo.Difficulty == Difficulty.Easy) pointsAdded = 10;
            if (doneTodo.Difficulty == Difficulty.Medium) pointsAdded = 20;
            if (doneTodo.Difficulty == Difficulty.Hard) pointsAdded = 30;
            if (doneTodo.Difficulty == Difficulty.VeryHard) pointsAdded = 40;

            userRepository.IncrementPoints(pointsAdded);

            mainThread.Post(() => callback.OnTodoMarkedDone(pointsAdded));
        }
    }
}
