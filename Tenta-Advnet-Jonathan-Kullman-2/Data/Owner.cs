using System.Collections.Generic;

namespace Tenta_Advnet_Jonathan_Kullman_2
{
    internal class Owner
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal virtual ICollection<Hamster> Hamsters { get; set; } 
    } 
}