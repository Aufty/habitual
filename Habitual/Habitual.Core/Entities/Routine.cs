namespace Habitual.Core.Entities
{
    public class Routine
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool IsActiveSunday { get; set; }
        public bool IsActiveMonday { get; set; }
        public bool IsActiveTuesday { get; set; }
        public bool IsActiveWednesday { get; set; }
        public bool IsActiveThursday { get; set; }
        public bool IsActiveFriday { get; set; }
        public bool IsActiveSaturday { get; set; }
    }
}
