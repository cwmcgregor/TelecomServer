using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TelecomAppBackend.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public int DeviceLimit { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        public ICollection<Device>?Devices { get; set; }
    }
}
