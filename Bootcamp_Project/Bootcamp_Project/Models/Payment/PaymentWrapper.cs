namespace Bootcamp_Project.Models.Payment
{
    public class PaymentWrapper
    {
        public int userId { get; set; }
        public List<PaymentMethodsResponse> paymentMethods { get; set; }
        public List<UserStoredPaymentsResponse> userStoredPaymentsResponses { get; set; }
    }
}
