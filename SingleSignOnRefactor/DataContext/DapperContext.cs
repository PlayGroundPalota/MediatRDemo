
using System.Data;
using MySql.Data.MySqlClient;

namespace SingleSignOnRefactor.DataContext
{
    public class DapperContext : IDapperContext
    {
        private readonly string? _connectionString;
        public DapperContext(IConfiguration _configuration)
        {
            var host = _configuration["DBHOST"] ?? "localhost";
            var port = _configuration["DBPORT"] ?? "3306";
            var password = _configuration["MYSQL_PASSWORD"] ?? _configuration.GetConnectionString("MYSQL_PASSWORD");
            var userid = _configuration["MYSQL_USER"] ?? _configuration.GetConnectionString("MYSQL_USER");
            var usersDataBase = _configuration["MYSQL_DATABASE"] ?? _configuration.GetConnectionString("MYSQL_DATABASE");

            _connectionString = $"server={host}; userid={userid};pwd={password};port={port};database={usersDataBase}";
        }

        public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
    }
}

