using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Entities
{
    public class TaskContainer
    {
        public List<Habit> Habits { get; set; }
        public List<Routine> Routines { get; set; }
        public List<Todo> Todos { get; set; }
        public List<HabitLog> HabitLogs { get; set; }
        public List<RoutineLog> RoutineLogs { get; set; }
    }
}
