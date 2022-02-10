using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> _employees = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович"},
            new Employee { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович" },
            new Employee { Id = 3, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович" }
        };

        public IActionResult Index()
        {
            //return Content("Данные из первого контроллера!");
            return View("Index");
        }

        //http://localhost:5000/home/ConfiguredAction/123?value=5555
        public ActionResult<string> ConfiguredAction(string id, string value)
        {
            return $"Hello world! {id} - {value}";
        }

        public IActionResult Employees()
        {
            return View(_employees);
        }
    }
}
