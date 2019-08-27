using Dapper;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DalMenu
    {
        public void Test()
        {
            using (var con = ConFactory.CreateMySqlCon())
            {
                //var aaa = con.Query<Menu>()
                string a = "aaaa";
            }
        }
    }
}
