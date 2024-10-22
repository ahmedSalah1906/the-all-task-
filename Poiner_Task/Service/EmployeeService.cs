using Poiner_Task.EmployeeViewModel;
using Poiner_Task.Models;
using Poiner_Task.Repository.Employees;
using Poiner_Task.Repository.Propertys;
using Poiner_Task.ViewModel;

namespace Poiner_Task.Service
{
    public class EmployeeService : IEmployeeservice
    {
        IEmployeeRepository empRepository;
        IPropertyRepository propertyRepository;
        public EmployeeService(IEmployeeRepository empRepository, IPropertyRepository propertyRepository)
        {
            this.empRepository = empRepository;
            this.propertyRepository = propertyRepository;
        }

        public void Create(EmployeeVm employeeVm)
        {
            var employee = new Employee
            {
                Name = employeeVm.Name,
                Code = employeeVm.Code,
                PropertyValues = employeeVm.CustomProperties.Select(customProperty => new PropertyValues
                {
                    PropertyId = customProperty.PropertyId,
                    Value = customProperty.Value 
                }).ToList()
            };

            empRepository.CreateEmp(employee);
        }

        public void DeleteById(int id)
        {
            var employee = empRepository.GetByIdEmp(id);
            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            empRepository.DeleteEmp(id);
        }

        public List<EmployeeVm> GetAllWithProperties()
        {
            var employees = empRepository.GetAllEmp();
            var globalProperties = propertyRepository.GetAllProperties();

            return employees.Select(employee => new EmployeeVm
            {
                Id = employee.EmployeeId,
                Name = employee.Name,
                Code = employee.Code,
                CustomProperties = globalProperties.Select(globalProp =>
                {
                    var propertyValue = employee.PropertyValues
                        .FirstOrDefault(p => p.PropertyId == globalProp.Id)?.Value;

                    return new propertyVm
                    {
                        PropertyId = globalProp.Id,
                        Name = globalProp.Name,
                        Type = globalProp.Type,
                        DropdownOptions = globalProp.DropdownOptions,
                        Value = propertyValue ?? string.Empty
                    };
                }).ToList()
            }).ToList();
        }

        public EmployeeVm GetById(int id)
        {
            var employee = empRepository.GetByIdEmp(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            var globalProperties = propertyRepository.GetAllProperties();

            return new EmployeeVm
            {
                Id = employee.EmployeeId,
                Name = employee.Name,
                Code = employee.Code,
                CustomProperties = globalProperties.Select(globalProp =>
                {
                    var propertyValue = employee.PropertyValues
                        .FirstOrDefault(p => p.PropertyId == globalProp.Id)?.Value;

                    return new propertyVm
                    {
                        PropertyId = globalProp.Id,
                        Name = globalProp.Name,
                        Type = globalProp.Type,
                        DropdownOptions = globalProp.DropdownOptions,
                        Value = propertyValue ?? string.Empty
                    };
                }).ToList()
            };
        }


        public EmployeeVm Update(int id ,EmployeeVm employeeVm)
        {
            var employee = empRepository.GetByIdEmp(id);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found.");
            }

            employee.Name = employeeVm.Name;
            employee.Code = employeeVm.Code;

            // Update property values
            foreach (var customProperty in employeeVm.CustomProperties)
            {
                var existingProperty = employee.PropertyValues
                    .FirstOrDefault(p => p.PropertyId == customProperty.PropertyId);

                if (existingProperty != null)
                {
                    existingProperty.Value = customProperty.Value; 
                }
                else
                {
                   
                    employee.PropertyValues.Add(new PropertyValues
                    {
                        PropertyId = customProperty.PropertyId,
                        Value = customProperty.Value
                    });
                }
            }

            var emp=empRepository.UpdateEmp(employee);
            return employeeVm;
        }
    }

        
    }


