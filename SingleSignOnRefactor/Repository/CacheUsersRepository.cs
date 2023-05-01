using System;
using Microsoft.Extensions.Caching.Memory;
using SingleSignOnRefactor.Models;

namespace SingleSignOnRefactor.Repository
{
    public class CacheUsersRepository : ISingleSignOnUserRepository
    {
        private readonly SingleSignOnUserRepository _decorated;
        private readonly IMemoryCache _memoryCache;

        public CacheUsersRepository(SingleSignOnUserRepository decorator, IMemoryCache memoryCache)
        {
            _decorated = decorator;
            _memoryCache = memoryCache;
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SingleSignOnDTO?> GetUser(int id)
        {
            return _memoryCache.GetOrCreateAsync($"user-{id}", entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetUser(id);
            });
        }

        public async Task<IEnumerable<SingleSignOnDTO>> GetUsers()
        {
            return await _memoryCache.GetOrCreateAsync("user-list", async entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return await _decorated.GetUsers();
            }) ?? Enumerable.Empty<SingleSignOnDTO>();
        }

        public Task InsertUser(SingleSignOnUserModel user) => _decorated.InsertUser(user);

        public Task UpdateUser(SingleSignOnDTO user) => _decorated.UpdateUser(user);
    }
}

