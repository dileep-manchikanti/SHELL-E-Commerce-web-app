using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.ProductDetails;
using Bootcamp_Project.Models.Products;

namespace Bootcamp_Project.Service
{
    public class ProductService
    {
        private readonly EF_DataContext _context;
        private readonly ILogger _logger;

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
                name = c.name,
                description = c.description,
                image = c.productImage
            }));
            return productList;
        }
    }
}
