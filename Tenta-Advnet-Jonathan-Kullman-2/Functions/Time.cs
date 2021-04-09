using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    internal class Time
    {
        private Ticker ticker;
         
        internal Time()
        {
            this.ticker = Ticker.GetInstance();
        }

        internal string DateString { get => StartTime.ToShortDateString(); }
        internal  DateTime StartTime { get; set; }
        internal  DateTime CurrentTime { get; set; }
        internal DateTime CalculateStartTime(int month, int day)
        {
            DateTime timeStamp = new DateTime(2021, month, day, 7, 0, 0);
            StartTime = timeStamp;
            return timeStamp;
        }
        internal void OnCalculateCurrentTime(object sender, EventArgs e)
        {
            int timeToAdd = ticker.tick * 6;
            DateTime timeStamp = StartTime.AddMinutes(timeToAdd);
            CurrentTime = timeStamp;
        }

    }
}
