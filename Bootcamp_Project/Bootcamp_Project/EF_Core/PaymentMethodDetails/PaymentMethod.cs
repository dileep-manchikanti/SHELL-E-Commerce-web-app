using Bootcamp_Project.EF_Core.UserDetails;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Bootcamp_Project.EF_Core.PaymentMethodDetails
{
    [Table("paymentMethod")]
    public class PaymentMethod
    {
        [Key][Required]
        public int Id { get; set; }
        [Required]
        public virtual User user { get; set; }
        [Required]
        public virtual PaymentType paymentType { get; set; }
        [AllowNull]
        public string UpiId {get; set; }
        [AllowNull]
        public string AccountNumber { get; set; }
        [AllowNull]
        public string CardNumber { get; set; }
        [AllowNull]
        public string ExpiryDate { get; set; }
        [AllowNull]
        public string CVV {  get; set; }


        [Required]
        public long createdDate { get; set; }
        public long updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; } = true;
    }
}
