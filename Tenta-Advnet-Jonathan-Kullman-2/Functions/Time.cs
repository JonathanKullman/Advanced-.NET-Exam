using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class Time
    {
        public DateTime StartTime { get; set; }
        public DateTime CurrentTime { get; set; }
        public DateTime CalculateStartTime(int month, int day)
        {
            DateTime timeStamp = new DateTime(2021, month, day, 7, 0, 0);
            StartTime = timeStamp;
            return timeStamp;
        }
        public void OnCalculateCurrentTime(object sender, EventArgs e)
        {
            int timeToAdd = Ticker.Tick * 6;
            DateTime timeStamp = StartTime.AddMinutes(timeToAdd);
            CurrentTime = timeStamp;
        }

    }
}
