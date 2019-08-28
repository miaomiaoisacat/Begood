using DAL.Appointment;
using Model.Entities;

namespace DAL
{
    public class RoleMenuActionRepository : RepositoryBase<RoleMenuAction>
    {
        public RoleMenuActionRepository() : base("role_menu_action")
        {
        }
    }
}
