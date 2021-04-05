using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
