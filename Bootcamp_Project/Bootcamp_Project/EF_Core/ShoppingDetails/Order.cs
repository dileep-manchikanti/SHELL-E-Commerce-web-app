using Bootcamp_Project.EF_Core.UserDetails;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Bootcamp_Project.EF_Core.PaymentMethodDetails;
using static Bootcamp_Project.Utils.CommonUtils;

namespace Bootcamp_Project.EF_Core.ShoppingDetails
{
    [Table("order")]
    public class Order
    {
        [Key,Required]
        public int Id { get; set; }
        [Required]
        public virtual User user { get; set; }

        [DefaultValue(PaymentMethods.COD)]
        public PaymentMethods paymentType { get; set; } = PaymentMethods.COD;
        
        public int addressId { get; set; }

        [Required,NotNull]
        public decimal totalAmount { get; set; }


        [DefaultValue(OrderStatus.Initiated)]
        public OrderStatus orderStatus { get; set; } = OrderStatus.Initiated;

        [Required]
        public long createdDate { get; set; }

        public long updatedDate { get; set; }

        [DefaultValue(true)]
        public bool status { get; set; } = true;


    }

    public enum OrderStatus
    {
        Initiated,
        Completed,
        Failure
    }
}
