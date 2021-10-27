using System.Data;

using Microsoft.Extensions.Options;

using Notos.Database.Interfaces;

using Npgsql;

namespace Notos.Database.Postgres
{
    public class PostgresConnection : IConnection
    {

        private readonly PostgresSettings _settings;

        public PostgresConnection(IOptions<PostgresSettings> settings)
        {
            _settings = settings.Value;
        }
        public IDbConnection CreateConnection()
        {
            var connection = new NpgsqlConnection(_settings.ConnectionString());
            connection.Open();

            return connection;
        }
    }
}
