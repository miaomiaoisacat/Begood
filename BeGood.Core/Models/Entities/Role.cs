namespace BeGood.Core.Models.Entities
{
    public class Role : BaseEntity
    {
        public int? ID { get; set; } = null;
        public int? ParentID { get; set; } = null;
        public string Name { get; set; } = null;
    }
}
