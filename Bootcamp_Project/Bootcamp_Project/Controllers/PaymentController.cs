using Bootcamp_Project.EF_Core;
using Bootcamp_Project.Models.Payment;
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
        [HttpGet("user/methods/{user_id}")]
        public IActionResult GetUserPaymentMethods(int user_id)
        {
            return paymentService.GetUserPaymentMethods(user_id);
        }


        //POST : api/<PaymentController>/user/methods/{user_id}
        [HttpPost("user/methods/{user_id}")]
        public IActionResult AddPaymentMethod([FromBody] AddPaymentRequest payment,int user_id)
        {
            return paymentService.AddPaymentMethod(payment,user_id);
        }

        //[HttpPut("user/methods/{user_payment_id}")]
        //public IActionResult UpdatePaymentMethod([FromBody] AddPaymentRequest payment,int user_payment_id)
        //{
        //    return paymentService.UpdatePaymentMethod(payment, user_payment_id);
        //}


    }
}
