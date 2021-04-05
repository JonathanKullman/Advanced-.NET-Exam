using System.Collections.Generic;

namespace Tenta_Advnet_Jonathan_Kullman_2
{  
    public class CageBuddies
    {
        public CageBuddies()
        {
            MaxCapacity = 3;
            hamsterList = new List<Hamster>();  
        }
        private List<Hamster> hamsterList;
        public int Id { get; set; }
        public int MaxCapacity { get; private set; }
        public bool IsFull { get => MaxCapacity - hamsterList.Count <= 0; }
        public Gender? Gender { get; set; }
        public int CageId { get; set; }
        public virtual Cage Cage { get; set; }

    }
}