using System.ComponentModel.DataAnnotations.Schema;

namespace Poiner_Task.Models
{
    public class PropertyValues
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Property")]
        public int PropertyId { get; set; }
        public string? Value { get; set; } 

        public Employee Employee { get; set; }
        public PropertyForEmployee Property { get; set; }
    }
}
