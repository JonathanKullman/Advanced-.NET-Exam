using System.Collections.Generic;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Hamster> Hamsters { get; set; } 
    } 
}