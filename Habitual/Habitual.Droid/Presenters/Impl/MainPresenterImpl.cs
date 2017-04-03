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
using Habitual.Core.Entities;
using Habitual.Core.Executors;
using Habitual.Core.Repositories;
using Habitual.Core.UseCases;
using Habitual.Core.UseCases.Impl;

namespace Habitual.Droid.Presenters.Impl
{
    public class MainPresenterImpl : AbstractPresenter, MainPresenter, CreateUserInteractorCallback, GetUserInteractorCallback
    {
        private MainView view;
        private UserRepository userRepository;

        public MainPresenterImpl(Executor executor, MainThread mainThread, MainView view,
                                 UserRepository userRepository) : base(executor, mainThread)
        {
            this.view = view;
            this.userRepository = userRepository;
        }

        public void GetUser(string username, string password)
        {
            GetUserInteractor getUserInteractor = new GetUserInteractorImpl(executor, mainThread, this, userRepository, username, password);
            getUserInteractor.Execute();
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

        public void OnInteractorError(string message)
        {
            OnError(message);
        }

        public void OnUserRetrieved(User user)
        {
            view.OnUserRetrieved(user);
        }
    }
}