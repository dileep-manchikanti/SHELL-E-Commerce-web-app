using Bootcamp_Project.EF_Core;
using Bootcamp_Project.Models.Payment;
using Bootcamp_Project.Utils;
using Microsoft.AspNetCore.Mvc;
using static Bootcamp_Project.Utils.CommonUtils;

namespace Bootcamp_Project.Service
{
    public class PaymentService:ControllerBase
    {
        private readonly ILogger _logger;
        private readonly EF_DataContext _context;
        public PaymentService(EF_DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }



        public IActionResult GetUserPaymentMethods(int user_id)
        {
            try
            {
                _logger.LogInformation("Inside GetUserPaymentMethods service");
                var paymentMethods = _context.PaymentTypes.Where(p => p.status == true).ToList();
                if (paymentMethods.Count == 0)
                {
                    return NotFound(new { errorCode = StatusCodes.Status404NotFound, errorMessage = "No Payment Methods found" });
                }
                List<PaymentMethodsResponse> paymentMethodsResponses = new List<PaymentMethodsResponse>();
                paymentMethods.ForEach(paymentMethod => paymentMethodsResponses.Add(new PaymentMethodsResponse()
                {
                    paymentTypeId = paymentMethod.Id,
                    paymentTypeName = paymentMethod.paymentMethod.ToString(),
                    image = paymentMethod.image
                }));
                _logger.LogInformation($"Total no of payment methods : {paymentMethodsResponses.Count}");



                var user = _context.Users.Where(u => u.status==true && u.Id == user_id);
                var userPaymentMethods = _context.PaymentMethods.Where(p => p.status == true && p.user.Id == user_id).ToList();
                List<UserStoredPaymentsResponse> userStoredPaymentsResponses = new List<UserStoredPaymentsResponse>();
                userPaymentMethods.ForEach(userPaymentMethod => userStoredPaymentsResponses.Add(new UserStoredPaymentsResponse()
                {
                    paymentTypeId = userPaymentMethod.Id,
                    paymentTypeName = userPaymentMethod.paymentType.paymentMethod.ToString(),
                    AccountNumber = userPaymentMethod.AccountNumber,
                    CVV = userPaymentMethod.CVV,
                    ExpiryDate = userPaymentMethod.ExpiryDate,
                    UpiId = userPaymentMethod.UpiId,
                    CardNumber = userPaymentMethod.CardNumber,
                }));
                _logger.LogInformation($"Total no of user payment methods : {userStoredPaymentsResponses.Count}");

                PaymentWrapper paymentWrapper = new PaymentWrapper()
                {
                    userId = user_id,
                    paymentMethods = paymentMethodsResponses,
                    userStoredPaymentsResponses = userStoredPaymentsResponses
                };
                return Ok(paymentWrapper);
            }
            catch (Exception ex) {
                return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError, errorMessage = ex.Message });
            }
        }

        public IActionResult AddPaymentMethod()
        {
            return Ok();
        }

    }
}
