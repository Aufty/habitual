﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Habitual.Core.Entities;
using Habitual.Core.Repositories;
using Habitual.Storage.Local;
using Newtonsoft.Json;

namespace Habitual.Storage
{
    public class TodoRepositoryImpl : TodoRepository
    {

        public void Create(Todo entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Todo> GetAllForUser(string username)
        {
            var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
            var unDoneTodos = taskContainer.Todos.Where(t => t.IsDone == false);
            return unDoneTodos.ToList();
        }

        public Todo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Todo MarkDone(Todo todo)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
            var matchingTodo = taskContainer.Todos.First(t => t.ID == todo.ID);
            var index = taskContainer.Todos.IndexOf(matchingTodo);
            taskContainer.Todos[index].IsDone = true;
            
            LocalData.TaskContainer = JsonConvert.SerializeObject(taskContainer);
            return taskContainer.Todos[index];
        }

        public void Update(Todo entity)
        {
            throw new NotImplementedException();
        }
    }
}