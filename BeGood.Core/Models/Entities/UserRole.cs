namespace BeGood.Core.Models.Entities
{
    public class UserRole : BaseEntity
    {
        public int? UserID { get; set; } = null;
        public int? RoleID { get; set; } = null;
    }
}
