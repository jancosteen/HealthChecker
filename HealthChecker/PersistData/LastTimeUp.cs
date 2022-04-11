using HealthChecker.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthChecker.PersistData
{
    public class LastTimeUp
    {
        [Key]
        public string Id { get; set; }
        public string LastTime { get; set; }
        [ForeignKey(nameof(Server))]
        public string ServerId { get; set; }
        public Server Server { get; set; }
    }

}
