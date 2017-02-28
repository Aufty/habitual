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
        Routine MarkDone(Routine routine); //TODO: should I pass UTC time?
        int GetPointValue(Difficulty difficulty);
    }
}
