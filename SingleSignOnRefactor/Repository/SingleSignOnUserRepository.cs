﻿using System;
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
            await _access.SaveData("storedProcedure", new { UserId = id });
        }

        public async Task<SingleSignOnDTO?> GetUser(int id)
        {
            var results = await _access.LoadData<SingleSignOnDTO, dynamic>(
            "GetSSOUserByLegacyId",
            new { Id = id });
            return results.FirstOrDefault();
        }

        public async Task<IEnumerable<SingleSignOnDTO>> GetUsers()
        {
            return await _access.LoadData<SingleSignOnDTO, dynamic>(storedProcedure: "GetUserList", new { });
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

    }
}

