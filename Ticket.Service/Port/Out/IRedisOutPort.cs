namespace Ticket.Service.Port.Out;

public interface IRedisOutPort
{
    Task SaveAsync<T>(string key, T value) where T : class;
    
    Task<T?> GetAsync<T>(string key) where T : class;

    Task DeleteAsync(string key);
}