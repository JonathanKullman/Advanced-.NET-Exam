using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{

        public class Ticker
        {
        private static Ticker ticker;
        public int tick;
        public event EventHandler Tiktok;


        public async Task Ticking(int speed)
        {
            Console.Clear();
            await Task.Run(() => Tiktok?.Invoke(this, EventArgs.Empty));
            tick++;
            await Task.Delay(10 * speed);
        }

        public static Ticker GetInstance()
        {
            if (ticker == null)
            {
                ticker = new Ticker();
            }
            return ticker;
        }



    }
}
