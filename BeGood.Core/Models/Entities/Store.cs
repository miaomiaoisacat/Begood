namespace BeGood.Core.Models.Entities
{
    public class Store : BaseEntity
    {
        public int? ID { get; set; } = null;
        public int? ParentID { get; set; } = null;
        public string Name { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Address { get; set; } = null;
        public string GpsPoint { get; set; } = null;
    }
}
