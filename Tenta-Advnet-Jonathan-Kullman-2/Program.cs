using System;
using System.IO;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    class Program
    {
        static void Main(string[] args)
        {

            MainAsync().GetAwaiter().GetResult();
            
        }

        private static async Task MainAsync()
        {
            //Checkar om databasen existerar, annars skapas den.
            var dbContext = new HamsterDbContext();
            await Task.Run(() => dbContext.Database.EnsureCreatedAsync());

            Simulation sim = new Simulation();
            await Task.Run(() => sim.Start());

            Console.ReadLine();
        }
    }
}
