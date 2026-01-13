using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ParkingApp.Data.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory, IDisposable
    {
        private readonly IConfigurationRoot _configuration;
        private bool _disposed;

        public ConnectionFactory()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        public IDbConnection GetConnection
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException(nameof(ConnectionFactory));

                var connectionString = _configuration.GetConnectionString("DefaultConnection");

                var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}
