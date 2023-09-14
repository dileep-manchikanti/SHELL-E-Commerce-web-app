namespace Bootcamp_Project.Models.Payment
{
    public class UserStoredPaymentsResponse
    {
        public string paymentTypeName {  get; set; }
        public int paymentTypeId { get; set; }
        public string UpiId { get; set; }
        public string AccountNumber { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
    }
}
