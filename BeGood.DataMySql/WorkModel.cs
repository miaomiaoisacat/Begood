using MySql.Data.MySqlClient;
using System;
using System.Text;

namespace BeGood.DataMySql
{
    public class WorkModel
    {
        public T aaa;

        public void Install<T>() where T : class, new()
        {

        }
    }

    //public class WorkModel<T> where T : class, new()
    //{
    //    public Func<T, string> SqlBuilder { get; set; }
    //    public T Data { get; set; }
    //}
}
