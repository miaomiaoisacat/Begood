using DAL.Appointment;
using Model.Entities;

namespace DAL
{
    public class MenuRepository : RepositoryBase<Menu>
    {
        public MenuRepository() : base("menu")
        {
        }
    }
}
