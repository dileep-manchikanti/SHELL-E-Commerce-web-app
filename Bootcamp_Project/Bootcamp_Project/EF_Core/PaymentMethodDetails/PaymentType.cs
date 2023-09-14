using Bootcamp_Project.Utils;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp_Project.EF_Core.PaymentMethodDetails
{
    [Table("paymentType")]
    public class PaymentType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public CommonUtils.PaymentMethods paymentMethod { get; set; }
        public string image { get; set; }
        [Required]
        public long createdDate { get; set; }
        public long updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }
    }

    
}
