using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bootcamp_Project.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public int phoneNumber { get; set; }
        public string Password { get; set; } = string.Empty;
        [DefaultValue(true)]
        public bool status { get; set; }
    }
}
