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


    }
}
