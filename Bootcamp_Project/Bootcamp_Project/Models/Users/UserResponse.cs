using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bootcamp_Project.Models.Users
{
    public class UserResponse
    {
        public string Email { get; set; } = string.Empty;
        public string phoneNumber { get; set; }
        public string fullName { get; set; }

    }
}
