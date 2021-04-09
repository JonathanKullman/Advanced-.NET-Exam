using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class UI
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

        public int GetAmountOfDays()
        {
            Console.WriteLine("How many days do you wish to simulate?");
            int userInput = int.Parse(Console.ReadLine());

            return userInput;
        }

        public int GetSpeed()
        {
            Console.WriteLine("[5 = 0,5 sec, 10 = 1 sec, 20 = 2 sec] etc...");
            Console.WriteLine("How fast do you want the program to run? 1 - 50");
            int speed = int.Parse(Console.ReadLine());
            return speed;
        }

        public async Task PrintOutDailyReport(string dailyReport)
        {
            Console.WriteLine(dailyReport.ToString());
            await Task.Delay(3000);

        }
        public void PrintOutTicklyReport(string ticklyReport)
        {
            Console.WriteLine(ticklyReport);
        }
    }
}
