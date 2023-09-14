using Bootcamp_Project.EF_Core.ProductDetails;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp_Project.EF_Core.ShoppingDetails
{
    [Table("cartItem")]
    public class CartItem
    {
        [Key][Required] public int Id { get; set; }
        [Required] public virtual Cart cart { get; set; }
        [Required] public virtual Product product { get; set; }
        [Required] public int quantity { get; set; }
        [Required] public long createdDate { get; set; }
        public long updatedDate { get; set; }
        [DefaultValue(true)] public bool status { get; set; }
    }
}
