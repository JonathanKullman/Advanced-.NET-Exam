using System.Collections.Generic;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class ExerciseArea
    {
        public List<Hamster> hamsterList;
        public ExerciseArea()
        {
            MaxCapacity = 6;
            hamsterList = new List<Hamster>();
        }
        public int Id { get; set; }
        public int MaxCapacity { get; private set; }
        public bool IsFull { get => MaxCapacity - hamsterList.Count <= 0; }

        public Gender? Gender { get; set; }
    }   
}