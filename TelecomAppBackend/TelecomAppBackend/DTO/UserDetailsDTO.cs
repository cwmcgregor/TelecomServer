using TelecomAppBackend.Models;

namespace TelecomAppBackend.DTO
{
    public class UserDetailsDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }



        public List<Plan>? Plans { get; set; }
    }
}
