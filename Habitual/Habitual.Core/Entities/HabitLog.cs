using System;

namespace Habitual.Core.Entities
{
    public class HabitLog
    {
        public int ID { get; set; }
        public int HabitID { get; set; }
        public DateTime TimestampUTC { get; set; }
    }
}
