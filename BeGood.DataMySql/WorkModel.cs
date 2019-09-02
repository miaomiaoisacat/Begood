using BeGood.Core.Models;
using System;

namespace BeGood.DataMySql
{
    public class WorkModel
    {
        public BaseEntity Data { get; set; }
        public Type DataType { get; set; }
        public Func<BaseEntity, string> SqlBuilder { get; set; }
    }
}
