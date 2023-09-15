using Bootcamp_Project.EF_Core;
using Bootcamp_Project.EF_Core.PaymentMethodDetails;
using Bootcamp_Project.EF_Core.UserDetails;
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

        public IActionResult AddPaymentMethod(AddPaymentRequest payment,int user_id)
        {
            try
            {
                _logger.LogInformation("Inside AddPaymentMethod");
                User user = _context.Users.FirstOrDefault(u => u.status==true && u.Id == user_id);
                if(user == null)
                {
                    return NotFound(new { errorCode = StatusCodes.Status404NotFound, errorMessage = "No user found" });
                }
                PaymentType paymentType = _context.PaymentTypes.FirstOrDefault(p => p.status == true && p.Id==payment.paymentTypeId);
                if(paymentType == null)
                {
                    return NotFound(new { errorCode = StatusCodes.Status404NotFound, errorMessage = "Invalid payment type" });
                }
                PaymentMethod paymentMethod = new PaymentMethod();
                paymentMethod.user = user;
                paymentMethod.paymentType = paymentType;
                bool flag = false;

                if(payment.paymentTypeId == 1)
                {
                    if (payment.UpiId != null)
                    {
                        paymentMethod.UpiId = payment.UpiId;
                        flag = true;
                    }
                }
                else if(payment.paymentTypeId == 2)
                {
                    if(payment.CardNumber != null && payment.ExpiryDate!=null && payment.CVV != null)
                    {
                        paymentMethod.CardNumber = payment.CardNumber;
                        paymentMethod.ExpiryDate = payment.ExpiryDate;
                        paymentMethod.CVV = payment.CVV;
                        flag = true;
                    }
                }
                else if(payment.paymentTypeId == 3)
                {
                    if (payment.AccountNumber != null)
                    {
                        payment.AccountNumber = payment.AccountNumber;
                        flag = true;
                    }
                }
                else if(payment.paymentTypeId == 4){ flag = true; }
                else
                {
                    return BadRequest(new { errorCode = 400, errorMessage = "Invalid payment type id" });
                }
                if (flag)
                {
                    _context.PaymentMethods.Add(paymentMethod);
                    _context.SaveChanges();
                    return Ok(paymentMethod);
                }
                return BadRequest(new { errorCode =400,errorMessage="Incomplete details"});
                
            }
            catch(Exception ex) { 
                return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError, errorMessage = ex.Message });
            }
        }

        //public IActionResult UpdatePaymentMethod(AddPaymentRequest newPayment,int user_payment_id) 
        //{
        //    try
        //    {
        //        _logger.LogInformation("inside UpdatePaymentMethod Service");
        //        PaymentMethod paymentMethod = _context.PaymentMethods.FirstOrDefault(
        //            p => p.status==true && p.Id == user_payment_id);

        //        bool flag = false;
        //        if(paymentMethod != null)
        //        {
        //            if (newPayment.paymentTypeId == 1)
        //            {
        //                if (newPayment.UpiId != null)
        //                {
        //                    paymentMethod.UpiId = newPayment.UpiId;
        //                    flag = true;
        //                }
        //            }
        //            else if (newPayment.paymentTypeId == 2)
        //            {
        //                if (newPayment.CardNumber != null && newPayment.ExpiryDate != null && newPayment.CVV != null)
        //                {
        //                    paymentMethod.CardNumber = newPayment.CardNumber;
        //                    paymentMethod.ExpiryDate = newPayment.ExpiryDate;
        //                    paymentMethod.CVV = newPayment.CVV;
        //                    flag = true;
        //                }
        //            }
        //            else if (newPayment.paymentTypeId == 3)
        //            {
        //                if (newPayment.AccountNumber != null)
        //                {
        //                    newPayment.AccountNumber = newPayment.AccountNumber;
        //                    flag = true;
        //                }
        //            }
        //            else if (newPayment.paymentTypeId == 4) { flag = true; }
        //            else
        //            {
        //                return BadRequest(new { errorCode = 400, errorMessage = "Invalid payment type id" });
        //            }
        //            if (flag)
        //            {
        //                _context.PaymentMethods.Update(paymentMethod);
        //                _context.SaveChanges();
        //                return Ok("Payment method updated successfully");
        //            }
        //            return BadRequest(new { errorCode = 400, errorMessage = "Incomplete details" });
        //        }
        //        return BadRequest(new {errorCode=400,errorMessage="Invalid user payment id"});
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(new { errorCode = StatusCodes.Status500InternalServerError, errorMessage = ex.Message });
        //    }
        //}

    }
}
