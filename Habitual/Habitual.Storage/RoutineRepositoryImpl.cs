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
    public class RoutineRepositoryImpl : RoutineRepository
    {
        public void Create(Routine entity)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
            taskContainer.Routines.Add(entity);
            LocalData.TaskContainer = JsonConvert.SerializeObject(taskContainer);
        }

        public void Delete(Guid id)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
            var matchingItem = taskContainer.Routines.First(r => r.ID == id);
            taskContainer.Routines.Remove(matchingItem);
            LocalData.TaskContainer = JsonConvert.SerializeObject(taskContainer);
        }

        public List<Routine> GetAllForUser(string username)
        {
            return null;
        }

        private List<Routine> RoutinesMatchingDay(List<Routine> routines, DayOfWeek dayOfWeek)
        {
            var day = dayOfWeek;
            if (day == DayOfWeek.Sunday)
            {
                var matchingRoutines = routines.Where(r => r.IsActiveSunday);
                return matchingRoutines.ToList();
            }
            if (day == DayOfWeek.Monday)
            {
                var matchingRoutines = routines.Where(r => r.IsActiveMonday);
                return matchingRoutines.ToList();
            }
            if (day == DayOfWeek.Tuesday)
            {
                var matchingRoutines = routines.Where(r => r.IsActiveTuesday);
                return matchingRoutines.ToList();
            }
            if (day == DayOfWeek.Wednesday)
            {
                var matchingRoutines = routines.Where(r => r.IsActiveWednesday);
                return matchingRoutines.ToList();
            }
            if (day == DayOfWeek.Thursday)
            {
                var matchingRoutines = routines.Where(r => r.IsActiveThursday);
                return matchingRoutines.ToList();
            }
            if (day == DayOfWeek.Friday)
            {
                var matchingRoutines = routines.Where(r => r.IsActiveFriday);
                return matchingRoutines.ToList();
            }
            if (day == DayOfWeek.Saturday)
            {
                var matchingRoutines = routines.Where(r => r.IsActiveSaturday);
                return matchingRoutines.ToList();
            }
            return new List<Routine>();
        }

        public Routine GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoutineLog> GetLogs(DateTime date, string username)
        {
            var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
            return taskContainer.RoutineLogs;
        }

        public int GetPointValue(Difficulty difficulty)
        {
            throw new NotImplementedException();
        }

        public Routine MarkDone(Routine routine, DateTime utcTimestamp)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);

            var routineLog = new RoutineLog();
            routineLog.ID = Guid.NewGuid();
            routineLog.RoutineID = routine.ID;
            routineLog.TimestampUTC = utcTimestamp;

            taskContainer.RoutineLogs.Add(routineLog);
            LocalData.TaskContainer = JsonConvert.SerializeObject(taskContainer);
            return routine;
        }

        public void Update(Routine entity)
        {
            throw new NotImplementedException();
        }

        public List<Routine> GetAllRoutinesIncludingOtherDays(string username)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            if (username.ToLower() == "admin")
            {
                var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
                return taskContainer.Routines;
            }
            return new List<Routine>();
        }

        public List<Routine> GetAllForUser(string username, DayOfWeek dayOfWeek)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            if (username.ToLower() == "admin")
            {
                var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
                return RoutinesMatchingDay(taskContainer.Routines, dayOfWeek);
            }

            return new List<Routine>();
        }
    }
}
