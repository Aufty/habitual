using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Habitual.Core.Executors;
using Habitual.Core.Repositories;
using Habitual.Core.UseCases;
using Habitual.Core.UseCases.Impl;

namespace Habitual.Android.Presenters.Impl
{
    public class MainPresenterImpl : AbstractPresenter, MainPresenter, CreateUserInteractorCallBack
    {
        private MainView view;
        private UserRepository userRepository;

        public MainPresenterImpl(Executor executor, MainThread mainThread, MainView view,
                                 UserRepository userRepository) : base(executor, mainThread)
        {
            this.view = view;
            this.userRepository = userRepository;
        }

        public void CreateUser(string username, string password)
        {
            CreateUserInteractor createUserInteractor = new CreateUserInteractorImpl(executor, mainThread, this, userRepository, username, password);
            createUserInteractor.Execute();
        }

        public void Destroy()
        {

        }

        public void OnError(string message)
        {
            
        }

        public void Pause()
        {
            
        }

        public void Resume()
        {
            
        }

        public void Stop()
        {
            
        }

        public void OnUserCreated()
        {
            view.OnUserCreated();
        }
    }
}