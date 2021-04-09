using System.Collections.Generic;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    internal class Cage
    {
        internal Cage()
        {
            MaxCapacity = 3;
            hamsterList = new List<Hamster>();  
        }
        internal List<Hamster> hamsterList;
        internal int Id { get; set; }
        internal int MaxCapacity { get; private set; }
        internal bool IsFull { get => MaxCapacity - hamsterList.Count <= 0; }
        internal Gender? Gender { get; set; }
        

    }
}