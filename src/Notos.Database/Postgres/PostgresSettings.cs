using Npgsql;

namespace Notos.Database.Postgres
{
    public class PostgresSettings
    {
        public string HostName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public int Port { get; set; } = 5432;

        public string ConnectionString()
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = HostName,
                Username = Username,
                Password = Password,
                Database = Database,
                Port = Port,
            };

            return builder.ConnectionString;
        }
    }
}
