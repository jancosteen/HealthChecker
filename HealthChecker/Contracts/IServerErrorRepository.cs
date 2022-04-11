using HealthChecker.Entities;
using System.Collections.Generic;

namespace HealthChecker.Contracts
{
    public interface IServerErrorRepository
    {
        IEnumerable<ServerError> GetAllServerErrorsPerServer(Server server);
    }
}
