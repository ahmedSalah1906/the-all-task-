
using Poiner_Task.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace Poiner_Task.EmployeeViewModel
{
    public class EmployeeVm
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 5 and 50 characters.")]
        public string Name { get; set; }
        public string Code { get; set; }
        [Required]
        public List<propertyVm> CustomProperties { get; set; } = new List<propertyVm>();
    }
}

