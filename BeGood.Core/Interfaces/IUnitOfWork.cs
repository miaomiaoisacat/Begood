using BeGood.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeGood.Core.Interfaces
{
    public interface IUnitOfWork
    {
        void Create<T>(T model) where T : BaseEntity, new();
        void Update<T>(T model) where T : BaseEntity, new();
        void Delete<T>(T model) where T : BaseEntity, new();
        bool Commit();
    }
}
