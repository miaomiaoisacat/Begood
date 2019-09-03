using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BeGood.Core.Interfaces;
using BeGood.Core.Models;
using Dapper;

namespace BeGood.DataMySql
{
    public abstract class BaseRepository : IRepository
    {
        private readonly IConFactory _conFactory;

        public BaseRepository(IConFactory conFactory)
        {
            this._conFactory = conFactory;
        }

        public T SelectSingle<T>(T model) where T : class, new()
        {
            T res = null;

            using (var con = this._conFactory.CreateCon())
            {
                try
                {
                    con.Open();
                    var arrProps = typeof(T).GetProperties();
                    StringBuilder builder = new StringBuilder();
                    builder.Append("select ");
                    for (int i = 0; i < arrProps.Length; i++)
                    {
                        builder.Append(arrProps[i].Name);
                        if (i< arrProps.Length -1)
                            builder.Append(",");
                    }
                    builder.Append(" from ");
                    builder.Append(EntityMapper.GetTableName(typeof(T)));
                    builder.Append(" where ");

                    //con.Query<T>()
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    if (con.State!= ConnectionState.Closed)
                        con.Close();
                }
            }

            return res;
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
