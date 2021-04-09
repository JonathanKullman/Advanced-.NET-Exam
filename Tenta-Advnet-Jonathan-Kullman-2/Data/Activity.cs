using System;
using System.Collections.Generic;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public enum Activities {CheckIn, DayCage, Exercise, CheckOut}
    public class Activity
    {
        public int Id { get; set; }

        public Activities ActivityType { get; set; }
        public DateTime? TimeOfStart { get; set; }
        public DateTime? TimeOfEnd { get; set; }
        public TimeSpan? TotalDuration { get => TimeOfEnd - TimeOfStart; }
        public int? ActivityLoggerId { get; set; }
        public virtual ActivityLogger ActivityLogger { get; set; }

    }
}