using Bootcamp_Project.Models.Price;
using System.ComponentModel.DataAnnotations;

namespace Bootcamp_Project.Models.Cart
{
    public class CartItemResponse
    {
        [Required] public int cartItemId {  get; set; }
        public string? productImage { get; set; }
        [Required] public string productName { get; set; }
        public string? productDescription { get; set; }
        [Required] public decimal productPrice { get; set; }
        [Required] public int quantity { get; set; }
        [Required] public decimal totalPrice { get; set; }
        [Required] public decimal totalTax { get; set; }
        [Required] public decimal totalDeliveryPrice { get; set; }
    }
}
