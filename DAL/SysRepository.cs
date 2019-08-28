using DAL.Appointment;
using Model.Entities;

namespace DAL
{
    public class SysRepository : RepositoryBase<Sys>
    {
        public SysRepository() : base("sys")
        {
        }
    }
}
