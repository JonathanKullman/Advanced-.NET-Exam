using System;
using System.Collections.Generic;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    internal enum Activities {CheckIn, DayCage, Exercise, CheckOut}
    internal class Activity
    {
        internal int Id { get; set; }

        internal Activities ActivityType { get; set; }
        internal DateTime? TimeOfStart { get; set; }
        internal DateTime? TimeOfEnd { get; set; }
        internal TimeSpan? TotalDuration { get => TimeOfEnd - TimeOfStart; }
        internal int? ActivityLoggerId { get; set; }
        internal virtual ActivityLogger ActivityLogger { get; set; }

    }
}