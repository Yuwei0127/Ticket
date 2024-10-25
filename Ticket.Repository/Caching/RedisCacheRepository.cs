using System.Diagnostics;
using System.Text.Json;
using StackExchange.Redis;
using Ticket.Service.Port.Out;

namespace Ticket.Repository.Caching;

public class RedisCacheRepository : IRedisOutPort
{
    private readonly IDatabase _redisDatabase;

    public RedisCacheRepository(IConnectionMultiplexer connectionMultiplexer)
    {
        _redisDatabase = connectionMultiplexer.GetDatabase();
    }
    
    // 泛型寫入方法
    public async Task SaveAsync<T>(string key, T value) where T : class
    {
        var json = JsonSerializer.Serialize(value);
        await _redisDatabase.StringSetAsync(key, json);
    }

    // 泛型讀取方法
    public async Task<T?> GetAsync<T>(string key) where T : class
    {
        var json = await _redisDatabase.StringGetAsync(key);
        return JsonSerializer.Deserialize<T>(json);
    }

    // 刪除資料
    public async Task DeleteAsync(string key)
    {
        await _redisDatabase.KeyDeleteAsync(key);
    }
    
    
}