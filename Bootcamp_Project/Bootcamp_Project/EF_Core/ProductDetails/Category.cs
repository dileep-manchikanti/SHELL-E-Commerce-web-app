using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp_Project.EF_Core.ProductDetails
{
    [Table("category")]
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        [DefaultValue(true)]
        public bool status { get; set; }
    }
}
