using System;
using System.Collections.Generic;
using Model.Entities;

namespace DAL.Appointment
{
    public interface IRepository
    {
        bool Create<T>(T model) where T : class, new();
        bool Update<T>(T model) where T : class, new();
        bool Delete(int id);
        bool Delete<T>(T model) where T : class, new();
        T SelectSingle<T>(T model) where T : class, new();
        List<T> SelectList();
        List<T> SelectList<T>(T model) where T : class, new();
        List<T> SelectPage<T>(T model, int pageIndex,int pageSize) where T : class, new();
    }
}
