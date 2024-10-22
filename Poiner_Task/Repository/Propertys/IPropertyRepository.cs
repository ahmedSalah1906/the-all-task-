using Poiner_Task.Models;

namespace Poiner_Task.Repository.Propertys
{
    public interface IPropertyRepository
    {
        public void DeleteProperty(int id);
        public PropertyForEmployee UpdateProperty(PropertyForEmployee property);
        public PropertyForEmployee GetPropertyById(int id);
        public List<PropertyForEmployee> GetAllProperties();
        public PropertyForEmployee AddProperty( PropertyForEmployee property);
      
    }
}
