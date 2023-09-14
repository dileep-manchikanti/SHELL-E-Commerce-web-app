using Bootcamp_Project.EF_Core;
using Bootcamp_Project.Models.Cart;
using Bootcamp_Project.Service;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService cartService;
        private readonly ILogger<CartController> logger;
        public CartController(EF_DataContext context, ILogger<CartController> logger)
        {
            cartService = new CartService(context, logger);
            this.logger = logger;
        }

        [HttpPost]
        [Route("add-cart-item")]
        public IActionResult AddCartItem([FromBody] CartItemAddRequest cartItemRequest)
        {
            try
            {
                return Ok(cartService.AddCartItem(cartItemRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = 500, errorMessage = ex.Message });
            }
        }

        [HttpPut]
        [Route("update-cart-item")]
        public IActionResult ModifyCartItem([FromBody] CartItemModifyRequest request)
        {
            try
            {
                return Ok(cartService.ModifyCartItem(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = 500, errorMessage = ex.Message });
            }
        }

        [HttpPut]
        [Route("remove-cart-item/{cartItemId}")]
        public IActionResult RemoveCartItem(int cartItemId)
        {
            try
            {
                return Ok(cartService.RemoveCartItem(cartItemId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = 500, errorMessage = ex.Message });
            }
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult CartDetail(int userId)
        {
            try
            {
                return Ok(cartService.GetCartDetail(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = 500, errorMessage = ex.Message });
            }
        }

    }
}
