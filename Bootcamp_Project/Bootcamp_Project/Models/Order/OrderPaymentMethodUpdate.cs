using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Bootcamp_Project.Models.Order
{
    public class OrderPaymentMethodUpdate
    {
        public int orderId { get; set; }
        public int paymentTypeId { get; set; }
    }
}
