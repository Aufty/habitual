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
    public class GetAllTodosInteractorImpl : AbstractInteractor, GetAllTodosInteractor
    {
        private GetAllTodosInteractorCallback callback;
        private TodoRepository todoRepository;
        private User user;

        public GetAllTodosInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        GetAllTodosInteractorCallback callback, TodoRepository todoRepository,
                                        User user) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.todoRepository = todoRepository;
            this.user = user;
        }

        public async override void Run()
        {
            try
            {
                var todos = await todoRepository.GetAll(user.Username);
                mainThread.Post(() => callback.OnTodosRetrieved(todos));
            } catch (Exception ex)
            {
                mainThread.Post(() => { callback.OnError($"Error retrieving todos. Error: {ex.Message}"); });
            }
            
        }
    }
}
