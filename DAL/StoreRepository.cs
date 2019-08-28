using DAL.Appointment;
using Model.Entities;

namespace DAL
{
    public class StoreRepository : RepositoryBase<Store>
    {
        public StoreRepository() : base("store")
        {
        }
    }
}
