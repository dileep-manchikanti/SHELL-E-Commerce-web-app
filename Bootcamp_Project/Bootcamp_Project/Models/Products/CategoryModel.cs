using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bootcamp_Project.Models.Products
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
    }
}
