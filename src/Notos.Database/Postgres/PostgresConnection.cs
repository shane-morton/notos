using System.Data;

using Microsoft.Extensions.Configuration;

using Notos.Database.Interfaces;

using Npgsql;

namespace Notos.Database.Postgres
{
    public class PostgresConnection : IConnection
    {

        private readonly IConfiguration _configuration;

        public PostgresConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("PostgresConnection"));
            connection.Open();

            return connection;
        }
    }
}
