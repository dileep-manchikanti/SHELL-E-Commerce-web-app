using Bootcamp_Project.EF_Core;
using Bootcamp_Project.Models.Cart;
using Bootcamp_Project.Models.Order;
using Bootcamp_Project.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;
        private readonly ILogger<OrderController> logger;
        public OrderController(EF_DataContext context, ILogger<OrderController> logger)
        {
            orderService = new OrderService(context, logger);
            this.logger = logger;
        }

        [HttpPost]
        [Route("initiate")]
        public IActionResult InitiateOrder([FromBody] OrderCreationRequest request)
        {
            try
            {
                return Ok(orderService.CreateOrder(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = 500, errorMessage = ex.Message });
            }
        }

        [HttpPost]
        [Route("update-address")]
        public IActionResult UpdateOrderAddress([FromBody] OrderAddressUpdate request)
        {
            try
            {
                return Ok(orderService.UpdateAddressInOrder(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = 500, errorMessage = ex.Message });
            }
        }

        [HttpPost]
        [Route("update-payment-method")]
        public IActionResult UpdateOrderPaymentMethod([FromBody] OrderPaymentMethodUpdate request)
        {
            try
            {
                return Ok(orderService.UpdatePaymentMethodInOrder(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorCode = 500, errorMessage = ex.Message });
            }
        }
    }
}
