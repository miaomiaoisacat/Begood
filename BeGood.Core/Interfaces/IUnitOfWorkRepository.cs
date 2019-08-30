using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BeGood.Core.Interfaces
{
    public interface IUnitOfWorkRepository<T> where T:class,new()
    {
        void AddCreate(Expression<Func<T, bool>> expression);
    }
}
