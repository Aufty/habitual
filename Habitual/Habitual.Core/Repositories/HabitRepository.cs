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
        int IncrementHabit(Habit habit); // returns new count
        int GetPointValue(Difficulty difficulty);
        List<HabitLog> GetLogs(DateTime date, string username);
    }
}
