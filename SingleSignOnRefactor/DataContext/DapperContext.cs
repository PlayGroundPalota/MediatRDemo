using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SingleSignOnRefactor.DataContext
{
    public class DapperContext : IDapperContext
    {
        private readonly string? _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}

