using Bootcamp_Project.EF_Core.ShoppingDetails;
using Bootcamp_Project.EF_Core.UserDetails;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp_Project.EF_Core.PaymentMethodDetails
{
    [Table("transaction")]
    public class Transaction
    {
        [Key][Required]
        public int Id { get; set; }
        [Required]
        public virtual User user { get; set; }
        [Required]
        public virtual Order order { get; set; }
        [Required]
        public virtual PaymentMethod paymentMethod { get; set; }
        [DefaultValue(TransactionStatus.Initiated)]
        public TransactionStatus transactionStatus { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }
    }

    public enum TransactionStatus
    {
        Initiated,
        Completed,
        Failure
    }
}
