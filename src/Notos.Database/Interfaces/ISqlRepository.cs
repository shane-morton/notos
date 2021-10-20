using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notos.Database.Interfaces
{
    public interface ISqlRepository
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);
        Task<int> ExecuteAsync(string sql, object param = null);
    }
}
