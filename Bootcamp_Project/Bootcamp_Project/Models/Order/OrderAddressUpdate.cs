using System.ComponentModel.DataAnnotations;

namespace Bootcamp_Project.Models.Order
{
    public class OrderAddressUpdate
    {
        [Required] public int orderId {  get; set; }
        [Required] public int addressId { get; set; }
    }
}
