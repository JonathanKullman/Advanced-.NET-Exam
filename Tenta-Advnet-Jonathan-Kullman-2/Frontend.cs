using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    class Frontend
    {
        public int GetMonth()
        {
            Console.Clear();
            Console.WriteLine("Enter which month you want: ");
            int month = int.Parse(Console.ReadLine());
            return month;
        }



        public int GetDay()
        {
            Console.Clear();
            Console.WriteLine("Enter which day you want: ");
            int day = int.Parse(Console.ReadLine());
            return day;
        }

        internal int GetAmountOfDays()
        {
            Console.WriteLine("How many days do you wish to simulate?");
            int userInput = int.Parse(Console.ReadLine());

            return userInput;
        }

        internal int GetSpeed()
        {
            Console.WriteLine("[5 = 0,5 sec, 10 = 1 sec, 20 = 2 sec] etc...");
            Console.WriteLine("How fast do you want the program to run? 1 - 50");
            int speed = int.Parse(Console.ReadLine());
            return speed;
        }

        internal async Task PrintDailyReport(string report)
        {
            Console.WriteLine(report.ToString());
            await Task.Delay(3000);

        }
    }
}
