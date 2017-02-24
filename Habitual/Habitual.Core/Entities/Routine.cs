using Habitual.Core.Entities.Base;

namespace Habitual.Core.Entities
{
    public class Routine : BaseTask
    {
        public bool IsActiveSunday { get; set; }
        public bool IsActiveMonday { get; set; }
        public bool IsActiveTuesday { get; set; }
        public bool IsActiveWednesday { get; set; }
        public bool IsActiveThursday { get; set; }
        public bool IsActiveFriday { get; set; }
        public bool IsActiveSaturday { get; set; }
    }
}
