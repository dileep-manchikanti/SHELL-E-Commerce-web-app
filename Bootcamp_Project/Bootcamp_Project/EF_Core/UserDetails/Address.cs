using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp_Project.EF_Core.UserDetails
{
    [Table("address")]
    public class Address
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public int postalCode { get; set; }
        public string landmark { get; set; }
        [Required]
        public long createdDate { get; set; }
        public long updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; } = true;

    }
}
