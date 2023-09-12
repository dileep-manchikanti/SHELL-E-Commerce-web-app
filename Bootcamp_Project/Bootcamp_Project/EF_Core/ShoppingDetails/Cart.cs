using Bootcamp_Project.EF_Core.UserDetails;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp_Project.EF_Core.ShoppingDetails
{
    [Table("cart")]
    public class Cart
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public virtual User user { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }
    }
}
