using System.Collections.Generic;

namespace OpenWeatherMap.Repository
{ 
    public interface IContext<T>
    {
        List<T> Weather { get; }
    }
}
