using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bootcamp_Project.EF_Core.GlobalVariables
{
    public class GlobalVariable
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        [DefaultValue(true)]
        public bool Status { get; set; } = true;
    }
}
