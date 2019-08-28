using DAL.Appointment;
using Model.Entities;

namespace DAL
{
    public class RoleRepository : RepositoryBase<Role>
    {
        public RoleRepository() : base("role")
        {
        }
    }
}
