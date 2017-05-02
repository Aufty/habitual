using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Entities
{
    public class Reward
    {
        public string Username { get; set; }
        public Guid ID { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
    }
}
