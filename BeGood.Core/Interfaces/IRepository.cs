using System.Collections.Generic;

namespace BeGood.Core.Interfaces
{
    public interface IRepository
    {
        T SelectSingle<T>(T model) where T : class, new();
        List<T> SelectList<T>() where T : class, new();
        List<T> SelectList<T>(T model) where T : class, new();
        List<T> SelectPage<T>(T model, int pageIndex, int pageSize) where T : class, new();
    }
}
