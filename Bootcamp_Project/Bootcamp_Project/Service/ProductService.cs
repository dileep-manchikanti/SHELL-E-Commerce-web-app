using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.ProductDetails;
using Bootcamp_Project.EF_Core.ShoppingDetails;
using Bootcamp_Project.Models.Cart;
using Bootcamp_Project.Models.FeedBack;
using Bootcamp_Project.Models.Price;
using Bootcamp_Project.Models.Products;
using Bootcamp_Project.Utils;

namespace Bootcamp_Project.Service
{
    public class ProductService
    {
        private readonly EF_DataContext _context;
        private readonly ILogger _logger;
        private readonly FeedBackService _feedBackService;

        public ProductService(EF_DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;  
        }

        public List<CategoryModel> GetCategories()
        {
            _logger.LogInformation("Inside GetCategories");

            var response = _context.Categories
                .Where(p => p.status == true)
                .ToList();
            List<CategoryModel> categories = new List<CategoryModel>();
            var totalCategories = categories.Count();
            _logger.LogInformation("Total number of categories fetched from db: {totalCategories}", totalCategories);

            response.ForEach(c => categories.Add(new CategoryModel
            {
                Id = c.Id,
                name = c.name,
                description = c.description,
                image = c.image,
            }));
            return categories;
        }

        public List<ProductListResponse> GetProductByCategory(string categoryName)
        {
            _logger.LogInformation("Inside GetProductByCategory");

            var response = _context.Products
                .Where(p => p.status == true && p.category.name == categoryName)
                .ToList();
            var productCount = response.Count();
            _logger.LogInformation("Total active product found for category {categoryName} are {productCount}", categoryName, productCount);

            List<ProductListResponse> productList = new List<ProductListResponse>();
            response.ForEach(c => productList.Add(new ProductListResponse{
                Id = c.Id,
                name = c.name,
                description = c.description,
                image = c.productImage
            }));
            return productList;
        }

        public ProductDetailResponse GetProductDetail(int productId)
        {
            _logger.LogInformation("Inside GetProductDetail");
            var product = _context.Products
               .FirstOrDefault(p => p.status == true && p.Id == productId);

            if (product == null) return new ProductDetailResponse();

            ProductDetailResponse productDetail = new ProductDetailResponse(product);

            ProductDeliveryDetails(productDetail);

            TotalPriceEstimation(product, productDetail);

            ReviewSummary reviewSummary = _feedBackService.GetReviewSummary(productId);
            if(reviewSummary != null)
            {
                productDetail.reviews = reviewSummary.reviews;
                productDetail.rating = reviewSummary.averageRating;
            }

            return productDetail;
        }

        private void TotalPriceEstimation(Product product, ProductDetailResponse productDetail)
        {
            decimal totalPrice = productDetail.basePrice;
            ProductTax productTax = new ProductTax();
            if(product.sgst != 0)
            {
                productTax.sgstRate = product.sgst;
                productTax.sgst = product.basePrice * (decimal)productTax.sgstRate / 100;
                totalPrice += productTax.sgst;
            }
            if (product.cgst != 0)
            {
                productTax.cgstRate = product.cgst;
                productTax.cgst = product.basePrice * (decimal)productTax.cgstRate / 100;
                totalPrice += productTax.cgst;
            }
            totalPrice += productDetail.deliveryPrice;
            productDetail.totalPrice = totalPrice;
        }

        private void ProductDeliveryDetails(ProductDetailResponse productDetail)
        {
            _logger.LogInformation("In ProductDeliveryDetails");
            var deliveryDayResponse = _context.GlobalVariables
                .FirstOrDefault(p => p.Status && p.Name == CommonUtils.NO_OF_DAYS_OF_DELIVERY);
            if (deliveryDayResponse != null)
            {
                productDetail.noOfDaysForDelivery = int.Parse(deliveryDayResponse.Value);
                _logger.LogInformation("Standard delivery days are {noOfDaysForDelivery}", productDetail.noOfDaysForDelivery);
                DateTime today = DateTime.Today;
                DateTime deliveryDate = today.AddDays(productDetail.noOfDaysForDelivery);
                string deliveryformattedDate = deliveryDate.ToString("dd-MM-yyyy");
                productDetail.deliveryDate = deliveryformattedDate;
            }

            var deliveryPriceResponse = _context.GlobalVariables
                .FirstOrDefault(p => p.Status && p.Name == CommonUtils.DELIVERY_PRICE_PERCENTAGE);
            if (deliveryPriceResponse != null)
            {
                _logger.LogInformation("Delivery Rate: {deliveryPriceResponse.Value}", deliveryPriceResponse.Value);
                productDetail.deliveryPrice = (productDetail.basePrice * int.Parse(deliveryPriceResponse.Value)) / 100;
            }
        }

        public decimal TaxEstimationForProductInCart(CartItem cartItem, int quantity)
        {
            decimal totalTax = 0;
            ProductTax productTax = new ProductTax();
            if (cartItem.product.sgst != 0)
            {
                productTax.sgstRate = cartItem.product.sgst;
                productTax.sgst = cartItem.product.basePrice * (decimal)productTax.sgstRate / 100;
                totalTax += productTax.sgst;
            }
            if (cartItem.product.cgst != 0)
            {
                productTax.cgstRate = cartItem.product.cgst;
                productTax.cgst = cartItem.product.basePrice * (decimal)productTax.cgstRate / 100;
                totalTax += productTax.cgst;
            }
            return totalTax * quantity;
        }

        public decimal ProductDeliveryPriceForCart(Product product, string productPrice, int quantity)
        {
            var deliveryPriceResponse = _context.GlobalVariables
                .FirstOrDefault(p => p.Status && p.Name == CommonUtils.DELIVERY_PRICE_PERCENTAGE);
            if (deliveryPriceResponse != null)
            {
                _logger.LogInformation("Delivery Rate: {deliveryPriceResponse.Value}", deliveryPriceResponse.Value);
                return int.Parse(productPrice) * int.Parse(deliveryPriceResponse.Value) * quantity / 100;
            }
            return new decimal(0);
        }
    }
}
