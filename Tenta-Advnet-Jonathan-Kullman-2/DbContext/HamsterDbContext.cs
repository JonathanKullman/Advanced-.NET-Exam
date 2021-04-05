using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class HamsterDbContext : DbContext
    {
        DbSet<Hamster> Hamsters { get; set; }
        DbSet<Cage> Cages { get; set; }
        DbSet<CageBuddies> Cagebuds { get; set; }
        DbSet<ExerciseArea> ExerciseAreas { get; set; }
        DbSet<Logger_Activities> Logger_Activities { get; set; }
        DbSet<Activity> Activities { get; set; }
        DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=advJonathanKullman;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Owner>().HasData(
                    new Owner { Id = 1, Name = "Kallegurra Aktersnurra" },
                    new Owner { Id = 2, Name = "Carl Hamilton" },
                    new Owner { Id = 3, Name = "Lisa Nilsson" },
                    new Owner { Id = 4, Name = "Jan Hallgren" },
                    new Owner { Id = 5, Name = "Ottilla Murkwood" },
                    new Owner { Id = 6, Name = "Anfers Murkwood" },
                    new Owner { Id = 7, Name = "Anna Book" },
                    new Owner { Id = 8, Name = "Pernilla Wahlgren" },
                    new Owner { Id = 9, Name = "Bianca Ingrosso" },
                    new Owner { Id = 10, Name = "Lorenzo Lamas" },
                    new Owner { Id = 11, Name = "Bobby Ewing" },
                    new Owner { Id = 12, Name = "Hedy Lamar" },
                    new Owner { Id = 13, Name = "Bette Davis" },
                    new Owner { Id = 14, Name = "Kim Carnes" },
                    new Owner { Id = 15, Name = "Mork of Ork" },
                    new Owner { Id = 16, Name = "Mindy Mendel" },
                    new Owner { Id = 17, Name = "GW Hansson" },
                    new Owner { Id = 18, Name = "Pia Hansson" },
                    new Owner { Id = 19, Name = "Bo Ek" },
                    new Owner { Id = 20, Name = "Anna Al" },
                    new Owner { Id = 21, Name = "Hans Björk" },
                    new Owner { Id = 22, Name = "Carita Gran" },
                    new Owner { Id = 23, Name = "Mia Eriksson" },
                    new Owner { Id = 24, Name = "Anna Linström" },
                    new Owner { Id = 25, Name = "Lennart Berg" },
                    new Owner { Id = 26, Name = "Bo Bergman" }
                    );

            string[] csvLines = File.ReadAllLines(@"C:\Users\jonte\source\repos\Tenta-Advnet-Jonathan-Kullman-2\Tenta-Advnet-Jonathan-Kullman-2\CSV FILE\Hamsterlista30.csv");
            Owner owner = new Owner();

            for (int i = 0; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(';');

                Hamster hamster = new Hamster();
                hamster.Id = int.Parse(data[5]);      
                hamster.Name = data[0];
                hamster.Age = int.Parse(data[1]);
                hamster.Gender = data[2] == "M" ? Gender.Male : Gender.Female;
                hamster.OwnerId = int.Parse(data[4]);


                modelBuilder.Entity<Hamster>().HasData(
                    new Hamster
                    {
                        Id = hamster.Id,
                        Name = hamster.Name,
                        Age = hamster.Age,
                        Gender = hamster.Gender,
                        OwnerId = hamster.OwnerId
                    }
                    );

                
            }
        }
    }
}
