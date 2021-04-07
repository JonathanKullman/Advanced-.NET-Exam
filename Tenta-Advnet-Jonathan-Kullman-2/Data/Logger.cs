using System;
using System.Collections.Generic;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class Logger
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int? HamsterId { get; set; }
        public virtual Hamster Hamster { get; set; }
        public int? ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
    }   
}