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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Routine> GetAllForUser(string username)
        {
            TemporaryStorageGenerator.InitializeTaskContainerIfRequired();
            if (username.ToLower() == "admin")
            {
                var taskContainer = JsonConvert.DeserializeObject<TaskContainer>(LocalData.TaskContainer);
                return RoutinesMatchingDay(taskContainer.Routines);
            }

            return new List<Routine>();
        }

        private List<Routine> RoutinesMatchingDay(List<Routine> routines)
        {
            var today = DateTime.Today;
            var day = today.DayOfWeek;
            if (day == DayOfWeek.Wednesday)
            {
                var matchingRoutines = routines.Where(r => r.IsActiveWednesday);
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
    }
}
