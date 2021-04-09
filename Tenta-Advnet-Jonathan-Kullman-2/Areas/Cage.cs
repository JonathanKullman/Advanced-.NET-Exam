using System.Collections.Generic;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class Cage
    {
        public Cage()
        {
            MaxCapacity = 3;
            hamsterList = new List<Hamster>();  
        }
        public List<Hamster> hamsterList;
        public int Id { get; set; }
        public int MaxCapacity { get; private set; }
        public bool IsFull { get => MaxCapacity - hamsterList.Count <= 0; }
        public Gender? Gender { get; set; }
        

    }
}