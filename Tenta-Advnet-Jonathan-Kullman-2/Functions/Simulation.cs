using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class Simulation
    {
        private EventHandler StartClock;

        private Ticker ticker;
        private Frontend frontend;
        private Time time;
        private int month;
        private int day;

        public Simulation()
        {
            time = new Time();
            ticker = new Ticker();
            frontend = new Frontend();
        }
        public void Start()
        {
            #region Subscribers

            StartClock += StartTicker;
            ticker.Tiktok += time.OnCalculateCurrentTime;
            ticker.Tiktok += Testshit;

            #endregion Subscribers

            //Asking user for month and day
            month = frontend.GetMonth();
            day = frontend.GetDay();       
           
            //Methods
            time.CalculateStartTime(month, day);

            //Invoking the event/simulation to start     
            StartClock?.Invoke(this, EventArgs.Empty);

        }

        private async void StartTicker(object sender, EventArgs e)
        {
            //Runs the event "ticking" which has numerous subs, asynchronously
            await Task.Run(() => ticker.Ticking());
        }

        private void Testshit(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tick: {Ticker.Tick}");
            sb.AppendLine($"StartTime = {time.StartTime}");
            sb.AppendLine($"CurrentTime = {time.CurrentTime}");
            Console.WriteLine(sb.ToString());


        }
    }
}
