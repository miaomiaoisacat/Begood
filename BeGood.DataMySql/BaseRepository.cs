using System.Collections.Generic;
using BeGood.Core.Interfaces;

namespace BeGood.DataMySql
{
    public abstract class BaseRepository : IRepository
    {
        private readonly string _conStr;

        public BaseRepository(string conStr)
        {
            this._conStr = conStr;
        }

        public T SelectSingle<T>(T model) where T : class, new()
        {
            return null;
        }

        public virtual List<T> SelectList<T>() where T : class, new()
        {
            return null;
        }

        public virtual List<T> SelectList<T>(T model) where T : class, new()
        {
            return null;
        }

        public virtual List<T> SelectPage<T>(T model, int pageIndex, int pageSize) where T : class, new() { return null; }
    }
}
