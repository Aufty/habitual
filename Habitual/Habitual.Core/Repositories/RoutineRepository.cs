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
        Task MarkDone(RoutineLog log);
        Task<List<RoutineLog>> GetLogs(DateTime date, string username);
        Task<List<Routine>> GetAllRoutinesForToday(string username);
    }
}
