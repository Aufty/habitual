using Habitual.Core.Entities.Base;
using System;

namespace Habitual.Core.Entities
{
    public class Todo : BaseTask
    {
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }
}
