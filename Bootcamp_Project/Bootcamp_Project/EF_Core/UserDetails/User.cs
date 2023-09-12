using Microsoft.AspNetCore.Mvc;
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
        [Phone]
        public int phoneNumber { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }
    }
}
