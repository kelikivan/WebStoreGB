using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    //[Route("empl/[action]/{id?}")]
    //[Route("Staff/{action=Index}/{id?}")]
    public class EmployeesController : Controller
    {
        private ICollection<Employee> _employees;
        public EmployeesController()
        {
            _employees = TestData.Employees;
        }

        public IActionResult Index()
        {
            return View(_employees);
        }

        //[Route("~/employees/info-{id}")]
        public IActionResult Details(int Id)
        {
            var employee = _employees.FirstOrDefault(t => t.Id == Id);
            
            if (employee is null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create() => View();

        public IActionResult Edit(int id)
        {
            var employee = _employees.FirstOrDefault(empl => empl.Id == id);
            if (employee is null)
            {
                return NotFound();
            }

            var model = new EmployeeEditViewModel
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Patronymic = employee.Patronymic,
                BirthDay = employee.BirthDay,
            };

            return View(model);
        }
        
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            // Обработка модели

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) => View();
    }
}
