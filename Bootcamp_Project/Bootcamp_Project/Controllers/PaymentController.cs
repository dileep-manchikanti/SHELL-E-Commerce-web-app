using Bootcamp_Project.EF_Core;
using Bootcamp_Project.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bootcamp_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService paymentService;
        private readonly ILogger<PaymentController> logger;
        public PaymentController(EF_DataContext context, ILogger<PaymentController> logger)
        {
            paymentService = new PaymentService(context, logger);
            this.logger = logger;
        }



        //GET : api/<PaymentController>/{user_id}
        [HttpGet("methods/{user_id}")]
        public IActionResult GetUserPaymentMethods(int user_id)
        {
            return paymentService.GetUserPaymentMethods(user_id);
        }


        
    }
}
