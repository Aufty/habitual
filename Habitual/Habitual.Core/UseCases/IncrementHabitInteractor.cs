using Habitual.Core.UseCases.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.Entities;

namespace Habitual.Core.UseCases
{
    public interface IncrementHabitInteractorCallback : InteractorCallback
    {
        void OnHabitIncremented(Habit habit, int pointsAdded);
    }
    public interface IncrementHabitInteractor : Interactor
    {
    }
}
