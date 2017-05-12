﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Entities.Base
{
    public abstract class BaseTask
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
