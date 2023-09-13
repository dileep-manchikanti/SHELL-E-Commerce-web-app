using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.ProductDetails;
using Bootcamp_Project.Models.Products;
using Bootcamp_Project.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bootcamp_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;
        private readonly ILogger<ProductController> logger;
        public ProductController(EF_DataContext context, ILogger<ProductController> logger)
        {
            productService = new ProductService(context, logger);
            this.logger = logger;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                IEnumerable<CategoryModel> categories = productService.GetCategories();
                if (!categories.Any())
                {
                    return NotFound(new {errorCode=404, errorMessage="No categories found in the db"});
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(new {errorCode=500,errorMessage=ex.Message});
            }
        }

        [HttpGet]
        [Route("product/{category}")]
        public IActionResult GetProductList(string category)
        {
            try
            {
                IEnumerable<ProductListResponse> productList = productService.GetProductByCategory(category);
                if (!productList.Any())
                {
                    return NotFound(new { errorCode = 404, errorMessage = "No product available for this category" });
                }
                return Ok(productList);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = 500, errorMessage = ex.Message });
            }
        }
    }
}
