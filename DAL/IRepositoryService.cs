using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL
{
    public interface IRepositoryService<T> where T : class,new()
    {
        T Create(T model);
        T Update(T model);
        T Delete(T model);
        T GetSingle(Expression<Func<T,T>> expression);
        List<T> GetList();
        List<T> GetList(Expression<Func<T, T>> expression);
    }
}
