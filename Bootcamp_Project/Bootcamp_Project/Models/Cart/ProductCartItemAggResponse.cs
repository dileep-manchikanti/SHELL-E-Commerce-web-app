using Bootcamp_Project.EF_Core.ProductDetails;
using Bootcamp_Project.EF_Core.ShoppingDetails;

namespace Bootcamp_Project.Models.Cart
{
    public class ProductCartItemAggResponse
    {
        public CartItem cartItem { get; set; }
        public Product product { get; set; }
    }
}
