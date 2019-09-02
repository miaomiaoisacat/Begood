using System.Data;

namespace BeGood.Core.Interfaces
{
    public interface IConFactory
    {
        string ConStr { get; set; }
        IDbConnection CreateCon();
    }
}
