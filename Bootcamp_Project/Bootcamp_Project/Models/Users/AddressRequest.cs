using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bootcamp_Project.Models.Users
{
    public class AddressRequest
    {
        public int userId {  get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int postalCode { get; set; }
        public string landmark { get; set; }
        [DefaultValue(false)]
        public bool isDefault { get; set; }
    }
}
