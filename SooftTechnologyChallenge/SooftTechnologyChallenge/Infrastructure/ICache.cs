using System.Threading.Tasks;

namespace SooftTechnologyChallenge.Infrastructure
{
    public interface ICache
    {
        Task AddAsync<T>(string key, T obj, int? durationInMinutes);
        Task<T> GetOrDefaultAsync<T>(string key);
        Task RemoveAsync(string key);
    }
}
