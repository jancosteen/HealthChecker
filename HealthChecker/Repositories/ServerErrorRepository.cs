using HealthChecker.Contracts;
using HealthChecker.Data;
using HealthChecker.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HealthChecker.Repositories
{
    public class ServerErrorRepository: IServerErrorRepository
    {
        private readonly AppData _appData;

        public ServerErrorRepository(AppData appData)
        {
            _appData = appData;
        }

        public IEnumerable<ServerError> GetAllServerErrorsPerServer(Server server)
        {          
            IEnumerable<ServerError> serverErrorData = _appData.errors.Where(x => x.ServerId.Equals(server.Id));
            foreach (ServerError error in serverErrorData)            {
                if(server.Status != "UP")
                {
                    error.Status = "500";
                    error.Body = "Internal Server Error";
                }
                else
                {
                    error.Status = "200";
                    error.Body = "Site Is Healthy";
                }
            }


            return serverErrorData;

            
        }
    }
}
