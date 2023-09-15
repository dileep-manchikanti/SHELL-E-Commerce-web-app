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
        public int categoryId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string? description { get; set; }

        public string? productImage { get; set; }

        public Guid SKU { get; set; }

        [Required]
        public int quantity { get; set; }

        [Required]
        public decimal basePrice { get; set; }
        
        [Required]
        public float cgst { get; set; }

        [Required]
        public float sgst { get; set; }

        public long createdDate { get; set; }

        public long updatedDate { get; set; }

        [DefaultValue(true)]
        public bool status { get; set; } = true;
    }
}
