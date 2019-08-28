using DAL.Appointment;
using Model.Entities;

namespace DAL
{
    public class StoreSysRepository : RepositoryBase<StoreSys>
    {
        public StoreSysRepository() : base("store_sys")
        {
        }
    }
}
