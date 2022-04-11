using HealthChecker.Contracts;
using HealthChecker.Data;
using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

            checkStatus();

            //httpClient.Dispose();

            return _appData.servers;
        }

        public Server GetById(string id)
        {
            checkStatus();
            return _appData.servers.SingleOrDefault(s => s.Id.ToUpper().Equals(id.ToUpper()) && s.VisibleFlg.ToUpper() != "FALSE");
        }

        public Server GetByName(string serverName)
        {
            checkStatus();
            return _appData.servers.SingleOrDefault(s => s.Name.ToUpper().Equals(serverName.ToUpper()) && s.VisibleFlg.ToUpper() != "FALSE");
        }

        public IEnumerable<Server> GetServersByStatus(string status)
        {
            checkStatus();
            return _appData.servers.Where(s => s.Status.ToUpper().Equals(status.ToUpper()) && s.VisibleFlg.ToUpper() != "FALSE").ToList();
        }

        public Server UpdateServer(Server dbServer)
        {
            if (dbServer.VisibleFlg.ToUpper() != "TRUE")
                dbServer.VisibleFlg = "TRUE";
            else
                dbServer.VisibleFlg = "FALSE";

            return dbServer;
        }

        private List<Server>checkStatus()
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

            return _appData.servers;
        }
    }
}
