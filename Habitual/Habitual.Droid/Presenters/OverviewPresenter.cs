
using Habitual.Core.Entities;
using Habitual.Droid.UI;

namespace Habitual.Droid.Presenters
{
    public interface OverviewView : BaseView
    {
        void OnTasksRetrieved(TaskContainer tasks);
        void OnHabitMarkedDone(int pointsAdded);
        void OnRoutineMarkedDone(int pointsAdded);
        void OnTodoMarkedDone(int pointsAdded);
    }

    public interface OverviewPresenter : BasePresenter
    {
        void GetTasks(string username, string password);
        void MarkHabitDone(Habit habit);
        void MarkRoutineDone(Routine routine);
        void MarkTodoDone(Todo todo);
    }
}