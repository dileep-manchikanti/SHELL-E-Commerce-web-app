namespace Bootcamp_Project.Models.Cart
{
    public class CartResponse
    {
        public int userId { get; set; }
        public int cartId { get; set; }
        public List<CartItemResponse> cartItems { get; set; }
        public decimal totalProductAmount { get; set; }
        public decimal totalTaxAmount { get; set; }
        public decimal totalDeliveryAmount { get; set; }
        public decimal totalCartAmount { get; set; }
    }
}
