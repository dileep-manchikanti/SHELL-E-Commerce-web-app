﻿using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.ProductDetails;
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
        public ProductController(EF_DataContext context)
        {
            productService = new ProductService(context);
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                IEnumerable<Category> categories = productService.GetCategories();
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
    }
}
