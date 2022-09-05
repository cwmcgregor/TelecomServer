using System.ComponentModel.DataAnnotations;



namespace TelecomAppBackend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
       public string Password { get; set; }



        public ICollection<Plan>? Plans { get; set; }
    }
}
