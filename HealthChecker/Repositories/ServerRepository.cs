using HealthChecker.Contracts;
using HealthChecker.Data;
using HealthChecker.Entities;
using HealthChecker.PersistData;
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

        private static ReadPersistedData _persistedData;

        public ServerRepository(AppData appData, ReadPersistedData persistedData)
        {
            _appData = appData;
            _persistedData = persistedData;
        }

        public IEnumerable<Server> GetAll()
        {
            ReadFile();
            checkStatus();
            WriteToFile();

            return _appData.servers.Where(s => s.VisibleFlg.ToUpper() != "FALSE");
        }


        public Server GetById(string id)
        {
            ReadFile();
            checkStatus();
            WriteToFile();
            return _appData.servers.SingleOrDefault(s => s.Id.ToUpper().Equals(id.ToUpper()) && s.VisibleFlg.ToUpper() != "FALSE");
        }

        public Server GetByIdNoFlg(string id)
        {
            ReadFile();
            checkStatus();
            WriteToFile();
            return _appData.servers.SingleOrDefault(s => s.Id.ToUpper().Equals(id.ToUpper()));
        }

        public Server GetByName(string serverName)
        {
            ReadFile();
            checkStatus();
            WriteToFile();
            return _appData.servers.SingleOrDefault(s => s.Name.ToUpper().Equals(serverName.ToUpper()) && s.VisibleFlg.ToUpper() != "FALSE");
        }

        public IEnumerable<Server> GetServersByStatus(string status)
        {
            ReadFile();
            checkStatus();
            WriteToFile();
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

        private void WriteToFile()
        {
            _persistedData.WriteData();
        }

        private void ReadFile()
        {
            _persistedData.ReadData();
        }
    }
}
