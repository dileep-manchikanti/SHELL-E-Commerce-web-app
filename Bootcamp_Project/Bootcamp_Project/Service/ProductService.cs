using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.ProductDetails;

namespace Bootcamp_Project.Service
{
    public class ProductService
    {
        private readonly EF_DataContext _context;

        public ProductService(EF_DataContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            var response = _context.Categories.ToList();
            List<Category> categories = new List<Category>();
            response.ForEach(c => categories.Add(new Category
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
