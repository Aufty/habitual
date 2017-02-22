namespace Habitual.Core.Entities
{
    public class Habit
    {
        public int UserID { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
