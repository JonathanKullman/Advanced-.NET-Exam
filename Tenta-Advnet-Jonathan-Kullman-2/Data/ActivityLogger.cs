using System;
using System.Collections.Generic;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    internal class ActivityLogger
    {
        internal int Id { get; set; }
        internal string Date { get; set; }
        internal int? HamsterId { get; set; }
        internal virtual Hamster Hamster { get; set; }
        internal virtual ICollection<Activity> Activities { get; set; }
    }   
}