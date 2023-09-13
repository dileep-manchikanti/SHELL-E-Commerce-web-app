using Bootcamp_Project.EF_Core.UserDetails;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Bootcamp_Project.EF_Core.PaymentMethodDetails;

namespace Bootcamp_Project.EF_Core.ShoppingDetails
{
    [Table("order")]
    public class Order
    {
        [Key,Required]
        public int Id { get; set; }
        [Required]
        public virtual User user { get; set; }
        [Required]
        public virtual PaymentMethod paymentMethod { get; set; }
        [Required]
        public virtual Address address { get; set; }
        [Required,NotNull]
        public decimal totalAmount { get; set; }
        [DefaultValue(OrderStatus.Initiated)]
        public OrderStatus orderStatus { get; set; }
        [Required]
        public long createdDate { get; set; }
        public long updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }


    }

    public enum OrderStatus
    {
        Initiated,
        Completed,
        Failure
    }
}
