﻿using System.Data;
using BeGood.Core.Interfaces;
using MySql.Data.MySqlClient;

namespace BeGood.DataMySql
{
    public class ConFactory : IConFactory
    {
        public string ConStr { get; set; }

        public IDbConnection CreateCon()
        {
            return new MySqlConnection(this.ConStr);
        }
    }
}
