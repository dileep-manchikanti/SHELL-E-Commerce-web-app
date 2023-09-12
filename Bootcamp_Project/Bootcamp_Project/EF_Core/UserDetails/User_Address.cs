using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp_Project.EF_Core.UserDetails
{
    [Table("userAddress")]
    public class User_Address
    {
        public int userid { get; set; }
        public int addressid { get; set; }
        public virtual User user { get; set; }
        public virtual Address address { get; set; }
        [DefaultValue(true)]
        public bool isDefault { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }
    }
}
