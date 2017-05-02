using Habitual.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Repositories
{
    public interface RoutineRepository : Repository<Routine>
    {
        Routine MarkDone(Routine routine, DateTime utcTimestamp);
        int GetPointValue(Difficulty difficulty);
        List<RoutineLog> GetLogs(DateTime date, string username);
        List<Routine> GetAllForUser(string username, DayOfWeek dayOfWeek);
        List<Routine> GetAllRoutinesIncludingOtherDays(string username);
    }
}
