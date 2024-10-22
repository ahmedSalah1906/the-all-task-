
using Poiner_Task.Models;

namespace Poiner_Task.Repository.Employees
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmp();
        public Employee GetByIdEmp(int id);
        public Employee CreateEmp(Employee employee);
        public void DeleteEmp(int id);
        public Employee UpdateEmp(Employee employee);



    }
}
