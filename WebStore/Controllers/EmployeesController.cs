using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    //[Route("empl/[action]/{id?}")]
    //[Route("Staff/{action=Index}/{id?}")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;
        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public IActionResult Index()
        {
            var result = _employeesService.GetAll();
            return View(result);
        }

        //[Route("~/employees/info-{id}")]
        public IActionResult Details(int Id)
        {
            var employee = _employeesService.GetById(Id);
            
            if (employee is null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create() => View();

        public IActionResult Edit(int id)
        {
            var employee = _employeesService.GetById(id);
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
        
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            var employee = new Employee
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Patronymic = model.Patronymic,
                BirthDay = model.BirthDay,
            };

            if (!_employeesService.Edit(employee))
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) => View();
    }
}
