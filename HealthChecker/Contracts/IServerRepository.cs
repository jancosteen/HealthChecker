using HealthChecker.Entities;
using System.Collections.Generic;

namespace HealthChecker.Contracts
{
    public interface IServerRepository
    {
        IEnumerable<Server> GetAll();
    }
}
