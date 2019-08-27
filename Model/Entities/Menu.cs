namespace Model.Entities
{
    public class Menu
    {
        public Menu() { }
        public int? ID { get; set; } = null;
        public int? ParentID { get; set; } = null;
        public int? SystemID { get; set; } = null;
        public string Name { get; set; } = null;
    }
}
