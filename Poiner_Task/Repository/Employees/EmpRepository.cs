using Microsoft.EntityFrameworkCore;

using Poiner_Task.Models;


namespace Poiner_Task.Repository.Employees
{
    public class EmpRepository : IEmployeeRepository
    {
        private readonly PoinerTaskContext _context;

        public EmpRepository(PoinerTaskContext context)
        {
            _context = context;
        }


        public List<Employee> GetAllEmp()
        {
            return _context.Employees
                .Include(e => e.PropertyValues)
                .ToList();
        }



        public Employee GetByIdEmp(int id)
        {
            return _context.Employees
                .Include(e => e.PropertyValues)
                .FirstOrDefault(e => e.EmployeeId == id);
        }


        public Employee CreateEmp(Employee employee)
        {
            if(employee == null) throw new ArgumentNullException(nameof(employee)); 
            var entery=_context.Employees.Add(employee);
            Save();
            return entery.Entity;

            

        }

       

        public Employee UpdateEmp(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            var entery = _context.Employees.Update(employee);
            Save();
            return entery.Entity;
        }


        public void DeleteEmp(int id)
        {
            var employee = GetByIdEmp(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                Save();
            }
        }
       
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
