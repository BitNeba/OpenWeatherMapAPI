using System;
using System.Threading.Tasks;

namespace OpenWeatherMap.Repository
{
    public interface IRepositoryAsync<T>
    {
        Task<T> FirstOrDefaultAsync(Func<T, bool> filter);
    }
}
