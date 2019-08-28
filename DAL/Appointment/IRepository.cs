using System;
using System.Collections.Generic;
using Model.Entities;

namespace DAL.Appointment
{
    public interface IRepository<T> where T: class,new()
    {
        bool Create(T model);
        bool Create(Func<T> func);
        bool Update(T model);
        bool Update(Func<T> func);
        bool Delete(int id);
        bool Delete(T model);
        bool Delete(Func<T> func);
        T SelectSingle(T model);
        List<T> SelectList();
        List<T> SelectList(T model);
        List<T> SelectPage(T model);
    }
}
