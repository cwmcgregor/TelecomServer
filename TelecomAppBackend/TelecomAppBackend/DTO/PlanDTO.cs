namespace TelecomAppBackend.DTO
{
    public class PlanDTO
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public int DeviceLimit { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
    }
}
