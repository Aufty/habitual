using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.Entities;
using Habitual.Core.Repositories;
using Habitual.Storage.Local;
using Newtonsoft.Json;

namespace Habitual.Storage
{
    public class HabitRepositoryImpl : HabitRepository
    {
        public void Create(Habit entity)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
            taskContainer.Habits.Add(entity);
            LocalData.TaskContainer = JsonConvert.SerializeObject(taskContainer);
        }

        public void Delete(Guid id)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
            var matchingItem = taskContainer.Habits.First(h => h.ID == id);
            taskContainer.Habits.Remove(matchingItem);
            LocalData.TaskContainer = JsonConvert.SerializeObject(taskContainer);
        }

        public List<Habit> GetAllForUser(string username)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();

            var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
            return taskContainer.Habits;
        }

        public Habit GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<HabitLog> GetLogs(DateTime date, string username)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            var habitLogList = new List<HabitLog>();
            try
            {
                var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
                var list = taskContainer.HabitLogs.Where(h => h.TimestampUTC.Date == DateTime.UtcNow.Date);
                habitLogList.AddRange(list);
            }
            catch (Exception)
            {

            }
            return habitLogList;
        }

        public int GetPointValue(Difficulty difficulty)
        {
            throw new NotImplementedException();
        }

        public int IncrementHabit(Habit habit)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            var log = new HabitLog();
            log.HabitID = habit.ID;
            log.ID = Guid.NewGuid();
            log.TimestampUTC = DateTime.UtcNow;
            var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
            taskContainer.HabitLogs.Add(log);

            var logs = taskContainer.HabitLogs.Where(h => h.HabitID == habit.ID);
            LocalData.TaskContainer = JsonConvert.SerializeObject(taskContainer);

            return logs.ToList().Count();
        }

        public void Update(Habit entity)
        {
            throw new NotImplementedException();
        }
    }


}
