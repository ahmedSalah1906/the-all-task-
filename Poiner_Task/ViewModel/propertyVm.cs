using Poiner_Task.Models;
using System.ComponentModel.DataAnnotations;

namespace Poiner_Task.ViewModel
{
    public class propertyVm
    {
        public int PropertyId { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 5 and 50 characters.")]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        public List<string>? DropdownOptions { get; set; } 
        public PropertyType Type { get; set; }
    }
}
