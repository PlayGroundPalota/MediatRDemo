using System;
using System.Data;

namespace SingleSignOnRefactor.DataContext
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}

