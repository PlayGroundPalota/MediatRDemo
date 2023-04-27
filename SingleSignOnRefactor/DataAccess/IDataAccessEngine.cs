using System;
namespace SingleSignOnRefactor.DataAccess
{
    public interface IDataAccessEngine
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters);
        Task SaveData<T>(string storedProcedure, T parameters);
    }
}

