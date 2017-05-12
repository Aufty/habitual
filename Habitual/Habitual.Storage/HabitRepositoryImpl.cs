using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.Entities;
using Habitual.Core.Repositories;
using Habitual.Storage.DB;
using Habitual.Storage.Local;
using Newtonsoft.Json;

namespace Habitual.Storage
{
    public class HabitRepositoryImpl : HabitRepository
    {
        public async void Create(Habit habit)
        {
            HabitDB habitManager = new HabitDB();
            await habitManager.CreateHabit(habit);
            return;
        }

        public async void Delete(Guid id)
        {
            HabitDB habitManager = new HabitDB();
            await habitManager.DeleteHabit(id);
            return;
        }

        public async Task<List<Habit>> GetAll(string username)
        {
            HabitDB habitManager = new HabitDB();
            var habits = await habitManager.GetAllHabits(username);
            return habits;
        }

        public async Task<List<Habit>> GetAllForUser(string username)
        {
            throw new NotImplementedException();
        }

        public Habit GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HabitLog>> GetLogs(DateTime date, string username)
        {
            HabitDB habitManager = new HabitDB();
            var logs = await habitManager.GetAllHabitLogs(date, username);
            return logs;
        }  

        public int GetPointValue(Difficulty difficulty)
        {
            throw new NotImplementedException();
        }

        public async void IncrementHabit(HabitLog log)
        {
            HabitDB habitManager = new HabitDB();
            await habitManager.LogHabit(log);
            return;
        }

        public void Update(Habit entity)
        {
            throw new NotImplementedException();
        }

        List<Habit> Repository<Habit>.GetAllForUser(string username)
        {
            throw new NotImplementedException();
        }
    }
}
