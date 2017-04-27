﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.Entities;
using Habitual.Core.Executors;
using Habitual.Core.Repositories;
using Habitual.Core.UseCases.Base;

namespace Habitual.Core.UseCases.Impl
{
    public class StoreUserLocalInteractorImpl : AbstractInteractor, StoreUserLocalInteractor
    {
        private StoreUserLocalCallback callback;
        private UserRepository userRepository;

        private User user;

        public StoreUserLocalInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        StoreUserLocalCallback callback, UserRepository userRepository,
                                        User user) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.userRepository = userRepository;
            this.user = user;
        }

        public override void Run()
        {
            if (user == null)
            {
                mainThread.Post(() => { callback.OnError("User cannot be empty"); });
                return;
            }

            userRepository.StoreLocally(user);

            mainThread.Post(() => { callback.OnUserStored(user); });
        }
    }
}
