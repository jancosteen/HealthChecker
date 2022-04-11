using HealthChecker.Contracts;
using HealthChecker.Data;
using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace HealthChecker.Repositories
{
    public class ServerRepository : IServerRepository
    {
        private static HttpClient httpClient = new HttpClient();

        private readonly AppData _appData;

        public ServerRepository(AppData appData)
        {
            _appData = appData;
        }

        public IEnumerable<Server> GetAll()
        {

            foreach (Server item in _appData.servers)
            {
                if (httpClient.GetAsync(item.HealthCheckUri).Result.IsSuccessStatusCode)
                {
                    item.Status = "UP";
                    item.LastTimeUp = DateTime.Now.ToString();
                }
                else
                {
                    item.Status = "DOWN";
                }
                    
            }

            //httpClient.Dispose();

            return _appData.servers;
        }

    }
}
