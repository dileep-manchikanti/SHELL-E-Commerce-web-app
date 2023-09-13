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
        public PaymentMethods paymentMethod { get; set; }
        [Required]
        public long createdDate { get; set; }
        public long updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }
    }

    public enum PaymentMethods
    {
        UPI,
        Card,
        COD,
        NetBanking
    }
}
