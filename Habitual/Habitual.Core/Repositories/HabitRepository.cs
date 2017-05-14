using Habitual.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Repositories
{
    public interface HabitRepository : Repository<Habit>
    {
        void IncrementHabit(HabitLog log); // returns new count
        Task<List<HabitLog>> GetLogs(DateTime date, string username);
    }
}
