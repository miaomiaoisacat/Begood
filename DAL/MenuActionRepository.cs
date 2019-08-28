using DAL.Appointment;
using Model.Entities;

namespace DAL
{
    public class MenuActionRepository : RepositoryBase<MenuAction>
    {
        public MenuActionRepository() : base("menu_action")
        {
        }
    }
}
