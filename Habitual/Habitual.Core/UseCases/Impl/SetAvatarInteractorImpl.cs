﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.Executors;
using Habitual.Core.Repositories;
using Habitual.Core.UseCases.Base;

namespace Habitual.Core.UseCases.Impl
{

    public class SetAvatarInteractorImpl : AbstractInteractor, SetAvatarInteractor
    {
        private SetAvatarInteractorCallback callback;
        private UserRepository userRepository;
        private string imageString;
        private string username;

        public SetAvatarInteractorImpl(Executor taskExecutor, MainThread mainThread,
                                        SetAvatarInteractorCallback callback, UserRepository userRepository, string username,
                                        string imageString) : base(taskExecutor, mainThread)
        {
            this.callback = callback;
            this.userRepository = userRepository;
            this.username = username;
            this.imageString = imageString;
        }

        public override void Run()
        {
            userRepository.SetAvatar(username, imageString);

            mainThread.Post(() => callback.OnAvatarSet(imageString));
        }
    }
}