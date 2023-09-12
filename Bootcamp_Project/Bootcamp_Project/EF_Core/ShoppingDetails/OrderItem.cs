using Bootcamp_Project.EF_Core.ProductDetails;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp_Project.EF_Core.ShoppingDetails
{
    [Table("orderItem")]
    public class OrderItem
    {
        //order_item: id, order_id, product_item_id, quantity

        [Key,Required]
        public int Id { get; set; }
        [Required]
        public virtual Order order { get; set; }
        [Required]
        public virtual Product product { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }

    }
}
