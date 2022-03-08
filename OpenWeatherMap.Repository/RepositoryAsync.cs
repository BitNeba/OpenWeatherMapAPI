using System;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWeatherMap.Repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T>
        where T : class
    {
        private readonly IContext<T> _inMemContext;

        public RepositoryAsync(IContext<T> inMemDataSource)
        {
            this._inMemContext = inMemDataSource;
        }


        public Task<T> FirstOrDefaultAsync(Func<T, bool> filter)
        {
            T result = _inMemContext.Weather.Where(filter).SingleOrDefault();

            return Task.FromResult(result);
        }
    }
}
