using Bootcamp_Project.EF_Core.ProductDetails;
using Bootcamp_Project.Models.Price;

namespace Bootcamp_Project.Models.Products
{
    public class ProductDetailResponse
    {
        public int Id { get; set; }
        public string productName { get; set; }
        public string? productDescription { get; set; }
        public int categoryId { get; set; }
        public string? productImage { get; set; }
        public Guid SKU { get; set; }
        public int quantity { get; set; }
        public decimal basePrice { get; set; }
        public decimal deliveryPrice { get; set; }
        public ProductTax taxDetails { get; set; }
        public decimal totalPrice { get; set; }
        public int noOfDaysForDelivery { get; set; }
        public string deliveryDate { get; set; }

        public ProductDetailResponse()
        {

        }

        public ProductDetailResponse(Product product)
        {
            this.Id = product.Id;
            this.productName = product.name;
            this.productDescription = product.description;
            this.productImage = product.productImage;
            this.categoryId = product.categoryId;
            this.SKU = product.SKU;
            this.quantity = product.quantity;
            this.basePrice = product.basePrice;
        }
    }

}
