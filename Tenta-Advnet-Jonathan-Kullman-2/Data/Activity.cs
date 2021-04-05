namespace Tenta_Advnet_Jonathan_Kullman_2
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Logger_ActivitiesId { get; set; }
        public virtual Logger_Activities Logger_Activities { get; set; }
    }
}