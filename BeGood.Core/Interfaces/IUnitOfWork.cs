using System;
using System.Collections.Generic;
using System.Text;

namespace BeGood.Core.Interfaces
{
    public interface IUnitOfWork
    {
        void Create<T>(T model) where T : class, new();
        void Update<T>(T model) where T : class, new();
        void Delete<T>(T model) where T : class, new();
        bool Commit();
    }
}
