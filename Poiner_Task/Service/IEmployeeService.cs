using Poiner_Task.EmployeeViewModel;

namespace Poiner_Task.Service
{
    public interface IEmployeeservice
    {
        
    
        public List<EmployeeVm> GetAllWithProperties();
        public EmployeeVm GetById(int id);
        public EmployeeVm Update(int id, EmployeeVm employeeVm);
        public void DeleteById(int id);
        public void Create(EmployeeVm employeeVm);
    }
}
