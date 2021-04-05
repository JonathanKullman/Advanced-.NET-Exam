using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
        public class Ticker
        {
        public static int Tick { get; set; }

        public event EventHandler Tiktok;
        public async Task Ticking()
        {
            while (Tick <= 100)
            {
                Console.Clear();
                Tiktok?.Invoke(this, EventArgs.Empty);
                Tick++;
                await Task.Delay(1000);
            }
            return;
        }


    }
}
