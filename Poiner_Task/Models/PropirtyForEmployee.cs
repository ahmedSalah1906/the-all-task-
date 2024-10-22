using System.ComponentModel.DataAnnotations.Schema;

namespace Poiner_Task.Models
{
    public enum PropertyType
    {
        String,
        Integer,
        Date,
        Dropdown
    }

    public class PropertyForEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PropertyType Type { get; set; } 
        public bool IsRequired { get; set; }
        public List< string>? DropdownOptions { get; set; } 
    }
}
