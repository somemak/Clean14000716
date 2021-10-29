using System;
using System.Threading.Tasks;
using Clean14000716.Domain.Entities;

namespace Clean14000716.Application.Common.Interfaces.Public
{
    public interface IRedisManager
    {
        Task Create<T>(string key, T data, TimeSpan? exTime = null, TimeSpan? unUseExTime = null);
        Task<T> Get<T>(string key);
        Task DeleteKeysForRequest(string endOfClass);
    }
}