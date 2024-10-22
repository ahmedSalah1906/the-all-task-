using Microsoft.AspNetCore.Mvc;
using Poiner_Task.EmployeeViewModel;
using Poiner_Task.Service;
using Poiner_Task.Service.Propertys;
using Poiner_Task.ViewModel;

namespace Poiner_Task.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeservice employeeService;
        IPropertyService propertyService;
        public EmployeeController(IEmployeeservice employeeService, IPropertyService propertyService)
        {
            this.employeeService = employeeService;
            this.propertyService = propertyService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees = employeeService.GetAllWithProperties();
            var prop = propertyService.GetAllGlobalProperties();
            ViewBag.prop = prop;
            return View("Index", employees);
        }

        [HttpGet]

        public IActionResult Create()
        {

            var globalProperties = propertyService.GetAllGlobalProperties();


            var employeeVm = new EmployeeVm
            {
                CustomProperties = globalProperties.Select(p => new propertyVm
                {
                    PropertyId = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    DropdownOptions = p.DropdownOptions
                }).ToList()
            };

            ViewBag.globalProperties = employeeVm.CustomProperties;


            return View("CreateEmp", employeeVm);
        }
        [HttpPost]
        public IActionResult Create(EmployeeVm employeeVm)
        {
            if (!ModelState.IsValid)
            {

                var globalProperties = propertyService.GetAllGlobalProperties();
                employeeVm.CustomProperties = globalProperties.Select(p => new propertyVm
                {
                    PropertyId = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    DropdownOptions = p.DropdownOptions,
                    Value = employeeVm.CustomProperties.FirstOrDefault(c => c.PropertyId == p.Id)?.Value



                }).ToList();

                return View("CreateEmp", employeeVm);
            }


            employeeService.Create(employeeVm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var employeeVm = employeeService.GetById(id);
            if (employeeVm == null)
            {
                return NotFound();
            }
            return View("EditEmp", employeeVm);
        }
        [HttpPost]
        public IActionResult Update(int id, EmployeeVm employeeVm)
        {
            if (id != employeeVm.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                employeeService.Update(employeeVm.Id, employeeVm);
                return RedirectToAction("Index");
            }

            return View(employeeVm);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            employeeService.DeleteById(id);
            return RedirectToAction("Index");
        }

    }
}
