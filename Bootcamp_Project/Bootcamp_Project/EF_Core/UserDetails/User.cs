using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Bootcamp_Project.EF_Core.UserDetails
{
    [Table("user")]
    public class User
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string hashedEmail { get; set; } = string.Empty;
        [Phone,Required]
        public string phoneNumber { get; set; }
        [Required]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        [Required]
        public DateTime dateOfBirth { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string salt { get; set; }
        [Required]
        public long createdDate { get; set; }
        public long updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }
    }
}
