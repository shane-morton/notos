using System.Data;

namespace Notos.Database.Interfaces
{
    public interface IConnection
    {
        IDbConnection CreateConnection();
    }
}
