using Microsoft.AspNetCore.Mvc;
using Poiner_Task.Models;

using Poiner_Task.Service.Propertys;



namespace Poiner_Task.Controllers
{
    public class PropertyController : Controller
    {
        IPropertyService propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            this.propertyService = propertyService;
        }
        public IActionResult Index()
        {
            var properties = propertyService.GetAllGlobalProperties();
            return View("Index", properties);
        }

        [HttpGet]
        public IActionResult Add()

        {
            var pro = new PropertyForEmployee();
            return View("createPro", pro);
        }

        [HttpPost]
        public IActionResult Add(PropertyForEmployee newProperty, List<string> DropDownOption = null)
        {
            if (newProperty.Type == PropertyType.Dropdown && DropDownOption != null)
            {
                newProperty.DropdownOptions = DropDownOption
                    .Where(option => !string.IsNullOrWhiteSpace(option))
                    .Select(option => option.Trim())
                .ToList();
            }

            propertyService.AddGlobalProperty(newProperty);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var property = propertyService.GetGlobalPropertyById(id);

            if (property == null)
            {
                return NotFound();
            }
            return View("EditPro", property);
        }

        [HttpPost]
        public IActionResult Edit(PropertyForEmployee updatedProperty)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedProperty);
            }

            propertyService.UpdateGlobalProperty(updatedProperty);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var property = propertyService.GetGlobalPropertyById(id);
            if (property == null)
            {
                return NotFound();
            }
            return View("Delete", property);
        }



        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var property = propertyService.GetGlobalPropertyById(id);
            if (property == null)
            {
                return NotFound();
            }

            propertyService.DeleteProperty(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
