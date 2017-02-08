namespace Habitual.Core.Entities
{
    public class Habit
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
