using Poiner_Task.Models;

namespace Poiner_Task.Service.Propertys
{
    public interface IPropertyService
    {
        public List<PropertyForEmployee> GetAllGlobalProperties();
        public PropertyForEmployee GetGlobalPropertyById(int id);
        public void DeleteProperty(int id);
        public PropertyForEmployee UpdateGlobalProperty(PropertyForEmployee property);
        public PropertyForEmployee AddGlobalProperty(PropertyForEmployee property);

    }
}
