using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthChecker.Entities
{
    public class ServerError
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Body { get; set; }

        [ForeignKey(nameof(Server))]
        public string ServerId { get; set; }
        public Server Server { get; set; }

    }

    
}
