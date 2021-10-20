using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Dapper;

using Notos.Database.Interfaces;

namespace Notos.Database.Repositories
{
    public class SqlRepository : ISqlRepository
    {
        private readonly IDbConnection _connection;

        public SqlRepository(IConnection connection)
        {
            _connection = connection.CreateConnection();
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            using var connection = _connection;
            return await connection.QueryAsync<T>(sql, param);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            using var connection = _connection;
            return await connection.ExecuteAsync(sql, param);
        }
    }
}
