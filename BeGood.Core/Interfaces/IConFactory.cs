using System.Data;

namespace BeGood.Core.Interfaces
{
    public interface IConFactory
    {
        IDbConnection CreateCon();
    }
}
