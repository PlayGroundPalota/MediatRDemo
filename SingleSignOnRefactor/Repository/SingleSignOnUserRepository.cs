using System;
using Dapper;
using System.Data;
using SingleSignOnRefactor.DataAccess;
using SingleSignOnRefactor.DataContext;
using SingleSignOnRefactor.Models;

namespace SingleSignOnRefactor.Repository
{
    public class SingleSignOnUserRepository : ISingleSignOnUserRepository
    {
        private readonly IDataAccessEngine _access;

        public SingleSignOnUserRepository(IDataAccessEngine access)
        {
            _access = access;
        }

        public async Task DeleteUser(int id)
        {
            await _access.SaveData("storedProcedure",
                new { UserId = id });
        }

        public async Task<SingleSignOnDTO?> GetUser(int id)
        {

            return await _access.Get<SingleSignOnDTO, dynamic>(
            "getUserById", new { UserId = id });
        }

        public async Task<IEnumerable<SingleSignOnDTO>> GetUsers()
        {
            return await _access.LoadData<SingleSignOnDTO,
                dynamic>(storedProcedure: "GetUserList", new { });
        }


        public async Task InsertUser(SingleSignOnUserModel user) =>

            await _access.SaveData(storedProcedure: "InsertUser",
                new
                {
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    AzureId = Guid.NewGuid().ToString()
                });


        public async Task UpdateUser(SingleSignOnDTO user) =>
              await _access.SaveData(storedProcedure: "storedProcedure",
                new
                {
                    Id = user.UserId,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    AzureUserId = user.AzureId
                });

        private async Task<int> GetTotalRecordsCount() =>
            (await _access.LoadData<int,
                dynamic>(storedProcedure: "GetUserListCount", new { })).Count();

    }
}

