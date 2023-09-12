using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp_Project.EF_Core.ProductDetails
{
    [Table("product")]
    public class Product
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public virtual Category category { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        public string productImage { get; set; }
        public Guid SKU { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }
    }
}
