using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class UI
    {

        /// <summary>
        /// gets the month of a date from user
        /// </summary>
        /// <returns></returns>
        public int GetMonth()
        {
            bool validInput = false;
            int month = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Set the month of the simulation");
                Console.Write(": ");
                bool checkInput = int.TryParse(Console.ReadLine(), out month);

                if (!checkInput)
                {
                    Console.Clear();
                    Console.WriteLine("Only a number is a valid input!");
                    Console.WriteLine("Press ENTER to try again...");
                    Console.ReadLine();
                }
                else
                {
                    validInput = true;
                }

            } while (!validInput);

            return month;
        }


        /// <summary>
        /// gets the day of a date from user
        /// </summary>
        /// <returns></returns>
        public int GetDay()
        {
            bool validInput = false;
            int day = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Set the start day of the simulation");
                Console.Write(": ");
                bool checkInput = int.TryParse(Console.ReadLine(), out day);

                if (!checkInput)
                {
                    Console.Clear();
                    Console.WriteLine("Only a number is a valid input!");
                    Console.WriteLine("Press ENTER to try again...");
                    Console.ReadLine();
                }
                else
                {
                    validInput = true;
                }

            } while (!validInput);

            return day;
        }

        /// <summary>
        /// gets the amount of days to simulate from user
        /// </summary>
        /// <returns></returns>
        public int GetAmountOfDays()
        {
            bool validInput = false;
            int days = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("How many days do you wish to simulate?");
                bool checkInput = int.TryParse(Console.ReadLine(), out days);

                if (!checkInput)
                {
                    Console.Clear();
                    Console.WriteLine("Only a number is a valid input!");
                    Console.WriteLine("Press ENTER to try again...");
                    Console.ReadLine();
                }
                else
                {
                    validInput = true;
                }

            } while (!validInput);

            return days;
        }

        /// <summary>
        /// Gets the speed for the ticks from user
        /// </summary>
        /// <returns></returns>
        public int GetSpeed()
        {
            bool validInput = false;
            int speed = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Set the speed for the simulation.");
                Console.Write("|1 = 100ms| : ");
                bool checkInput = int.TryParse(Console.ReadLine(), out speed);

                if (!checkInput)
                {
                    Console.Clear();
                    Console.WriteLine("Only a number is a valid input!");
                    Console.WriteLine("Press ENTER to try again...");
                    Console.ReadLine();
                }
                else
                {
                    validInput = true;
                }

            } while (!validInput);

            return speed;
        }

        /// <summary>
        /// Prints the daily report on screen
        /// </summary>
        /// <param name="dailyReport"></param>
        /// <returns></returns>
        public async Task PrintOutDailyReport(string dailyReport)
        {
            Console.WriteLine(dailyReport.ToString());
            await Task.Delay(5000);

        }
        
        /// <summary>
        /// Prints the daily report on screen
        /// </summary>
        /// <param name="ticklyReport"></param>
        public void PrintOutTicklyReport(string ticklyReport)
        {
            Console.WriteLine(ticklyReport);
        }
    }
}
