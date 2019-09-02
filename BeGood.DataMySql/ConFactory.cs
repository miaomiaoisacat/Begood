using System.Data;
using BeGood.Core.Interfaces;
using MySql.Data.MySqlClient;

namespace BeGood.DataMySql
{
    public class ConFactory : IConFactory
    {
        private string _conStr;

        public string ConStr { get => this._conStr; set => this._conStr = value; }

        public ConFactory(string conStr)
        {
            this._conStr = conStr;
        }

        public IDbConnection CreateCon()
        {
            return new MySqlConnection(this.ConStr);
        }
    }
}
