using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> _employees = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", BirthDay = new DateTime(1990,01,07) },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", BirthDay = new DateTime(1995, 02, 18) },
            new Employee { Id = 3, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", BirthDay = new DateTime(2000, 03, 27) }
        };

        public IActionResult Index()
        {
            var result = _employees;
            return View(result);
        }

        public IActionResult Details(int Id)
        {
            var employee = _employees.FirstOrDefault(t => t.Id == Id);
            
            if (employee is null)
            {
                return NotFound();
            }

            return View(employee);
        }
    }
}
