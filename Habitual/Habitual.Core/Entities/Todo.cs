using System;

namespace Habitual.Core.Entities
{
    public class Todo
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }
}
