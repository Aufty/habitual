﻿using System;

namespace Habitual.Core.Entities
{
    public class RoutineLog
    {
        public int ID { get; set; }
        public int RoutineID { get; set; }
        public DateTime TimestampUTC { get; set; }
    }
}
