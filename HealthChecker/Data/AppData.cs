using HealthChecker.Entities;
using System.Collections.Generic;

namespace HealthChecker.Data
{
    public class AppData
    {
        public List<Server> servers = new List<Server>{
            new Server{
                Id = "1",
                Name = "stackworx.io",
                HealthCheckUri = "https://www.stackworx.io",
            },
            new Server{
                Id = "2",
                Name = "prima.run",
                HealthCheckUri = "https://prima.run",
            },
            new Server{
                Id = "3",
                Name = "google",
                HealthCheckUri = "https://www.google.com",
            },
        };

        public List<ServerError> errors = new List<ServerError>
        {
            new ServerError
            {
                Id = "1",
                ServerId = "1",
            },
            new ServerError
            {
                Id = "2",
                ServerId = "2",
            },
            new ServerError
            {
                Id = "3",
                ServerId = "3",
            },

        };
    }
}
