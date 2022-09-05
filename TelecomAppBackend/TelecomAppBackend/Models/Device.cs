using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TelecomAppBackend.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
     
        public string PhoneNumber { get; set; }
        public int PlanId { get; set; }
        [JsonIgnore]
        public virtual Plan? Plan { get; set; }
    }
}
