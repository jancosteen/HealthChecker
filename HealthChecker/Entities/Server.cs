using System;
using System.ComponentModel.DataAnnotations;

namespace HealthChecker.Entities
{
    public class Server
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string HealthCheckUri { get; set; }
        public string Status { get; set; }
        public string? LastTimeUp { get; set; }

        public ServerError? Error { get; set; }

    }
}
