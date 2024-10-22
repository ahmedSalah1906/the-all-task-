using Poiner_Task.Models;

namespace Poiner_Task.Repository.Propertys
{
    public class PropertyRepository : IPropertyRepository
    {
        PoinerTaskContext _context;
        public PropertyRepository(PoinerTaskContext context) 
        { 
            _context = context;
        }
        public PropertyForEmployee AddProperty( PropertyForEmployee property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            var entery=_context.propirtyForEmployees.Add(property);
            Save();
            return entery.Entity;

        }

        public void DeleteProperty(int id)
        {
            var pro=GetPropertyById(id);
            if (pro != null)
            {
                _context.propirtyForEmployees.Remove(pro);
                Save();
            }

        }

        public List<PropertyForEmployee> GetAllProperties()
        {
           return _context.propirtyForEmployees.ToList();
        }

        public PropertyForEmployee GetPropertyById(int id)
        {
            
            var pro= _context.propirtyForEmployees.FirstOrDefault(x => x.Id == id);
            if (pro != null)
            {  return pro; }
            return null;
            
        }
        

        public PropertyForEmployee UpdateProperty(PropertyForEmployee property)
        {
            if (property == null) throw new ArgumentNullException(nameof(property));
            var entery = _context.propirtyForEmployees.Update(property);
            Save();
            return entery.Entity;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
