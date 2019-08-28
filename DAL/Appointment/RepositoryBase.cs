using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Appointment
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, new()
    {
        public string TableName { get; set; }

        public RepositoryBase(string tableName)
        {
            this.TableName = tableName;
        }

        public virtual bool Create(T model)
        {
            bool res = default;
            using (var con = ConFactory.CreateMySqlCon())
            {
                var arrProps = typeof(T).GetProperties();

                StringBuilder builder = new StringBuilder();
                builder.Append("insert into ");
                builder.Append(this.TableName);
                builder.Append(" (");
                for (int i = 0; i < arrProps.Length; i++)
                {
                    if (arrProps[i].Name == "ID")
                        continue;
                    if (i> 0)
                        builder.Append(",");
                    builder.Append(arrProps[i].Name);
                }
                builder.Append(") ");
                builder.Append("values (");
                for (int i = 0; i < arrProps.Length; i++)
                {
                    if (arrProps[i].Name == "ID")
                        continue;
                    if (i > 0)
                        builder.Append(",");
                    builder.Append("@");
                    builder.Append(arrProps[i].Name);
                }
                builder.Append(")");

                if (con.Execute(builder.ToString(), model) > 0)
                    res = true;
            }
            return res;
        }

        public virtual bool Update(T model)
        {
            bool res = default;
            using (var con = ConFactory.CreateMySqlCon())
            {
                var arrProps = typeof(T).GetProperties();

                StringBuilder builder = new StringBuilder();
                builder.Append("update ");
                builder.Append(this.TableName);
                builder.Append(" set");
                for (int i = 0; i < arrProps.Length; i++)
                {
                    if (arrProps[i].Name == "ID")
                        continue;
                    if (i > 0)
                        builder.Append(",");
                    builder.Append(arrProps[i].Name);
                    builder.Append("=@");
                    builder.Append(arrProps[i].Name);
                }
                builder.Append(" where ID=@ID");

                if (con.Execute(builder.ToString(), model) > 0)
                    res = true;
            }
            return res;
        }

        public virtual bool Delete(T model)
        {
            bool res = default;
            using (var con = ConFactory.CreateMySqlCon())
            {
                var arrProps = typeof(T).GetProperties();

                StringBuilder builder = new StringBuilder();
                builder.Append("delete from ");
                builder.Append(this.TableName);
                builder.Append(" where ID=@ID");

                if (con.Execute(builder.ToString(), model) > 0)
                    res = true;
            }
            return res;
        }

        public virtual T SelectSingle(T model)
        {
            T outT = null;
            using (var con = ConFactory.CreateMySqlCon())
            {
                var arrProps = typeof(T).GetProperties();

                StringBuilder builder = new StringBuilder();
                builder.Append("select * from ");
                builder.Append(this.TableName);
                builder.Append(" where ");
                for (int i = 0; i < arrProps.Length; i++)
                {
                    if (null == arrProps[i].GetValue(model))
                        continue;
                    if (i > 0)
                        builder.Append(" and ");
                    builder.Append(arrProps[i].Name);
                    builder.Append("=@");
                    builder.Append(arrProps[i].Name);
                }

                outT = con.Query<T>(builder.ToString(), model).SingleOrDefault();
            }
            return outT;
        }

        public virtual List<T> SelectList(T model)
        {
            List<T> lstOut = null;
            using (var con = ConFactory.CreateMySqlCon())
            {
                var arrProps = typeof(T).GetProperties();

                StringBuilder builder = new StringBuilder();
                builder.Append("select * from ");
                builder.Append(this.TableName);
                builder.Append(" where ");
                for (int i = 0; i < arrProps.Length; i++)
                {
                    if (null == arrProps[i].GetValue(model))
                        continue;
                    if (i > 0)
                        builder.Append(" and ");
                    builder.Append(arrProps[i].Name);
                    builder.Append("=@");
                    builder.Append(arrProps[i].Name);
                }

                lstOut = con.Query<T>(builder.ToString(), model).ToList();
            }
            return lstOut;
        }

        public virtual List<T> SelectPage(T model)
        {
            return null;
        }
    }
}
