using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenWeatherMap.Repository
{
    public class InMemoryContext<T> : IContext<T>
    {
        private readonly IConfiguration _config;
        private static Object thisLock = new Object();

        public List<T> Weather { get; set; }

        public InMemoryContext(IConfiguration config)
        {
            this._config = config;
            InitDataSource();
        }

        private void InitDataSource()
        {
            lock (thisLock)
            {
                if (Weather == null)

                {
                    try
                    {
                        string json = System.IO.File.ReadAllText(_config["InMemoryDatabase:DatabasePath"]);
                  
                        Weather = JsonSerializer.Deserialize<List<T>>(json);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
    }
}
