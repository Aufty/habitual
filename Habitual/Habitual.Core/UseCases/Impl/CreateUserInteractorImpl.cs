﻿using Habitual.Core.Entities;
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
    public class CreateUserInteractorImpl : AbstractInteractor, CreateUserInteractor
    {
        private CreateUserInteractorCallBack callback;
        private UserRepository userRepository;

        private string username;
        private string password;

        public CreateUserInteractorImpl(Executor taskExecutor, MainThread mainThread, 
                                        CreateUserInteractorCallBack callback, UserRepository userRepository,
                                        string username, string password) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.userRepository = userRepository;
            this.username = username;
            this.password = password;
        }

        public override void Run()
        {
            User user = new User(username, password);
            userRepository.Create(user);

            // notify main thread that user was added
            mainThread.Post(callback.OnUserCreated);
        }
    }
}
