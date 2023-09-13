using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.ProductDetails;
using Bootcamp_Project.Models.Products;

namespace Bootcamp_Project.Service
{
    public class ProductService
    {
        private readonly EF_DataContext _context;

        public ProductService(EF_DataContext context)
        {
            _context = context;
        }

        public List<CategoryModel> GetCategories()
        {
            var response = _context.Categories.ToList();
            List<CategoryModel> categories = new List<CategoryModel>();
            response.ForEach(c => categories.Add(new CategoryModel
            {
                Id = c.Id,
                name = c.name,
                description = c.description,
                image = c.image,
            }));
            return categories;
        }
    }
}
