
using System.Data;
using MySql.Data.MySqlClient;

namespace SingleSignOnRefactor.DataContext
{
    public class DapperContext : IDapperContext
    {
        private readonly string? _connectionString;
        public DapperContext(IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
    }
}

