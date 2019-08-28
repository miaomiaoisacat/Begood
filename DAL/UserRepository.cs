using DAL.Appointment;
using Model.Entities;

namespace DAL
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository() : base("user")
        {
        }
    }
}
