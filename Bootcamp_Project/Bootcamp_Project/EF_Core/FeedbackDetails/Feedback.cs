using Bootcamp_Project.EF_Core.ShoppingDetails;
using Bootcamp_Project.EF_Core.UserDetails;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp_Project.EF_Core.FeedbackDetails
{
    [Table("feedback")]
    public class Feedback
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public virtual User user { get; set; }

        [Required]
        public virtual Order order { get; set; }

        [Required]
        public float rating { get; set; }

        [Required]
        public int productId { get; set; }

        public string comments { get; set; }

        [Required]
        public long createdDate { get; set; }

        public long updatedDate { get; set; }

        [DefaultValue(true)]
        public bool status { get; set; }
    }

}
