using BeGood.Core.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BeGood.DataMySql
{
    public class UnitOfWorkMySql:IUnitOfWork
    {
        private readonly string _tableName;
        private readonly string _conStr;

        public List<WorkModel<T>> Works { get; set; }

        public UnitOfWorkMySql(string tableName, string conStr)
        {
            this._tableName = tableName;
            this._conStr = conStr;
            this.Works = new List<WorkModel<T>>();
        }

        public bool Commit()
        {
            bool res = false;

            try
            {
                using (var con = new MySqlConnection(this._conStr))
                {
                    con.Open();
                    MySqlTransaction trans = con.BeginTransaction();
                    try
                    {

                        foreach (var item in this.Works)
                        {
                            con.Execute(item.SqlBuilder.Invoke(item.Data), item.Data, trans);
                        }
                        trans.Commit();
                        this.Works.Clear();
                        res = true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return res;
        }

        public void Create(T model)
        {
            this.Works.Add(new WorkModel<T>
            {
                Data = model,
                SqlBuilder = new Func<T, string>(x =>
                {

                    var arrProps = typeof(T).GetProperties();
                    StringBuilder builder = new StringBuilder();
                    bool isNeedComma = false;

                    builder.Append("insert into ");
                    builder.Append(this._tableName);
                    builder.Append(" (");

                    for (int i = 0; i < arrProps.Length; i++)
                    {
                        if (null == arrProps[i].GetValue(x))
                            continue;

                        if (isNeedComma)
                        {
                            builder.Append(",");
                            isNeedComma = false;
                        }

                        builder.Append(arrProps[i].Name);
                        isNeedComma = true;
                    }

                    isNeedComma = false;

                    builder.Append(") ");
                    builder.Append("values (");

                    for (int i = 0; i < arrProps.Length; i++)
                    {
                        if (null == arrProps[i].GetValue(x))
                            continue;

                        if (isNeedComma)
                        {
                            builder.Append(",");
                            isNeedComma = false;
                        }

                        builder.Append("@");
                        builder.Append(arrProps[i].Name);
                        isNeedComma = true;
                    }

                    builder.Append(")");
                    return builder.ToString();
                })
            });
        }

        public void Delete(T model)
        {
            this.Works.Add(new WorkModel<T>()
            {
                Data = model,
                SqlBuilder = new Func<T, string>(x =>
                {
                    var arrProps = typeof(T).GetProperties();
                    StringBuilder builder = new StringBuilder();
                    bool isNeedAnd = false;

                    builder.Append("delete from ");
                    builder.Append(this._tableName);
                    builder.Append(" where ");

                    for (int i = 0; i < arrProps.Length; i++)
                    {
                        if (null == arrProps[i].GetValue(x))
                            continue;

                        if (isNeedAnd)
                        {
                            builder.Append(" and ");
                            isNeedAnd = false;
                        }

                        builder.Append(arrProps[i].Name);
                        builder.Append("=@");
                        builder.Append(arrProps[i].Name);
                        isNeedAnd = true;
                    }

                    return builder.ToString();
                })
            });
        }

        public void Update(T model)
        {
            this.Works.Add(new WorkModel<T>
            {
                Data = model,
                SqlBuilder = new Func<T, string>(x =>
                {
                    var arrProps = typeof(T).GetProperties();
                    StringBuilder builder = new StringBuilder();
                    bool isNeedComma = false;

                    builder.Append("update ");
                    builder.Append(this._tableName);
                    builder.Append(" set ");
                    for (int i = 0; i < arrProps.Length; i++)
                    {
                        if (null == arrProps[i].GetValue(x))
                            continue;

                        if (isNeedComma)
                        {
                            builder.Append(",");
                            isNeedComma = false;
                        }

                        builder.Append(arrProps[i].Name);
                        builder.Append("=@");
                        builder.Append(arrProps[i].Name);
                        isNeedComma = true;
                    }
                    builder.Append(" where ID=@ID");
                    return builder.ToString();
                })
            });
        }

        public void Create<T>(T model) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T model) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T model) where T : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
