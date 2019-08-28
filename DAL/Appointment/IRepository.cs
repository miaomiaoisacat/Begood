using System.Collections.Generic;

namespace DAL.Appointment
{
    interface IRepository<T> where T: class,new()
    {
        bool Create(T model);
        bool Update(T model);
        bool Delete(T model);
        T SelectSingle(T model);
        List<T> SelectList(T model);
        List<T> SelectPage(T model);
    }
}
