using System.Data;
using MySql.Data.MySqlClient;

namespace BeGood.DataMySql
{
    public static class ConFactory
    {
        public static string ConStr { get; set; }

        public static IDbConnection CreateCon()
        {
            return new MySqlConnection(ConFactory.ConStr);
        }
    }
}
