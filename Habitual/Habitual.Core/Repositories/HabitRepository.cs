using Habitual.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Repositories
{
    public interface HabitRepository
    {
        void Create(Habit habit);
        void Delete(int id);
        void Update(Habit habit);
        Habit GetHabitById(int id);
        List<Habit> GetAllHabitsForUser(string username);
        int IncrementHabit(int habitID); // returns new count
        int GetPointValue(Difficulty difficulty);
    }
}
