using HealthChecker.Entities;
using System.Collections.Generic;

namespace HealthChecker.Contracts
{
    public interface IServerRepository
    {
        IEnumerable<Server> GetAll();
        Server GetByName(string serverName);
        IEnumerable<Server> GetServersByStatus(string status);
    }
}
