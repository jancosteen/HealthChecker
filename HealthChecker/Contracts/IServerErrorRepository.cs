using HealthChecker.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChecker.Contracts
{
    public interface IServerErrorRepository
    {
        IEnumerable<ServerError> GetAllServerErrorsPerServer(Server server);

    }
}
