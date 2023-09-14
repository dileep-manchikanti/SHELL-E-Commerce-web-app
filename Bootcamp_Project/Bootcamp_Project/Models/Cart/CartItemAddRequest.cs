using System.ComponentModel.DataAnnotations;

namespace Bootcamp_Project.Models.Cart
{
    public class CartItemAddRequest
    {
        [Required]
        public int userId { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public int quantity { get; set; }
    }
}
