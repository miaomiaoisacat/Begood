using System;
using System.Collections.Generic;
using System.Text;

namespace BeGood.Core.Interfaces
{
    public interface IUnitOfWork
    {
        bool Create<T>(T model) where T : class, new();
        bool Update<T>(T model) where T : class, new();
        bool Delete<T>(T model) where T : class, new();
        bool Delete<T>(int id);
        bool Commit();
    }
}
