namespace Bootcamp_Project.Models.Users
{
    public class RegisterRequest
    {
        public string Email { get; set; } = string.Empty;
        public string phoneNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string password { get; set; }
    }
}
