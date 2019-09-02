using BeGood.Core.Interfaces;
using BeGood.Core.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BeGood.DataMySql
{
    public class UnitOfWorkMySql : IUnitOfWork
    {
        private readonly IConFactory _conFactory;

        public List<WorkModel> Works { get; set; }

        public UnitOfWorkMySql(IConFactory conFactory)
        {
            this.Works = new List<WorkModel>();
            this._conFactory = conFactory;
        }

        public bool Commit()
        {
            bool res = false;

            try
            {
                using (var con = _conFactory.CreateCon())
                {
                    con.Open();
                    IDbTransaction trans = con.BeginTransaction();
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
                    finally
                    {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return res;
        }

        public void Create<T>(T model, string tableName) where T : BaseEntity, new()
        {
            this.Works.Add(new WorkModel
            {
                Data = model,
                DataType = typeof(T),
                SqlBuilder = new Func<BaseEntity, string>(x =>
                {
                    var arrProps = typeof(T).GetProperties();
                    StringBuilder builder = new StringBuilder();
                    bool isNeedComma = false;

                    builder.Append("insert into ");
                    builder.Append(EntityMapper.GetTableName(typeof(T)));
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

        public void Update<T>(T model, string tableName) where T : BaseEntity, new()
        {
            this.Works.Add(new WorkModel
            {
                Data = model,
                DataType = typeof(T),
                SqlBuilder = new Func<BaseEntity, string>(x =>
                {
                    var arrProps = typeof(T).GetProperties();
                    StringBuilder builder = new StringBuilder();
                    bool isNeedComma = false;

                    builder.Append("update ");
                    builder.Append(EntityMapper.GetTableName(typeof(T)));
                    builder.Append(" set ");
                    for (int i = 0; i < arrProps.Length; i++)
                    {
                        if (null == arrProps[i].GetValue(x))
                            continue;
                        if (arrProps[i].Name == "ID")
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

        public void Delete<T>(T model, string tableName) where T : BaseEntity, new()
        {
            this.Works.Add(new WorkModel
            {
                Data = model,
                DataType = typeof(T),
                SqlBuilder = new Func<BaseEntity, string>(x =>
                {
                    var arrProps = typeof(T).GetProperties();
                    StringBuilder builder = new StringBuilder();
                    bool isNeedAnd = false;

                    builder.Append("delete from ");
                    builder.Append(EntityMapper.GetTableName(typeof(T)));
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
    }
}
