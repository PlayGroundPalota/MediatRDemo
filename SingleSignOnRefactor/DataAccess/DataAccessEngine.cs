using System;
using Dapper;
using System.Data;
using SingleSignOnRefactor.DataContext;

namespace SingleSignOnRefactor.DataAccess
{
    public class DataAccessEngine : IDataAccessEngine
    {
        private readonly IDapperContext _dapperContext;

        public DataAccessEngine(IDapperContext dapperContext)
        {
            this._dapperContext = dapperContext;
        }
        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task SaveData<T>(string storedProcedure, T parameters)
        {
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

