using System.ComponentModel.DataAnnotations;

namespace Bootcamp_Project.Models.Order
{
    public class OrderCreationRequest
    {
        [Required] public int userId { get; set; }
        [Required] public decimal totalAmount { get; set; }
    }
}
