using MySql.Data.MySqlClient;
using System.Data;

namespace DAL.Appointment
{
    public class ConFactory
    {
        private static string _conStr;

        public static void Install(string conStr)
        {
            ConFactory._conStr = conStr;
        }

        public static IDbConnection CreateCon<T>() where T: IDbConnection,new()
        {
            IDbConnection con = new T();
            con.ConnectionString = ConFactory._conStr;
            con.Open();
            return con;
        }

        public static IDbConnection CreateMySqlCon()
        {
            return ConFactory.CreateCon<MySqlConnection>();
        }
    }
}
