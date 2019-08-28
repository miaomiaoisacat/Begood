using DAL.Appointment;
using Model.Entities;

namespace DAL
{
    public class UserRoleRepository : RepositoryBase<UserRole>
    {
        public UserRoleRepository() : base("user_role")
        {
        }
    }
}
