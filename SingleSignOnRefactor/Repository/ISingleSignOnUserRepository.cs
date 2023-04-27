using System;
using SingleSignOnRefactor.Models;

namespace SingleSignOnRefactor.Repository
{
    public interface ISingleSignOnUserRepository
    {
        Task DeleteUser(int id);
        Task<SingleSignOnDTO?> GetUser(int id);
        Task<IEnumerable<SingleSignOnDTO>> GetUsers();
        Task InsertUser(SingleSignOnUserModel user);
        Task UpdateUser(SingleSignOnDTO user);
    }
}

