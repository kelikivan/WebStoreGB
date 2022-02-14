using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return Content("Данные из первого контроллера!");
            return View("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        public void Throw(string message)
        {
            throw new ApplicationException(message);
        }


        //http://localhost:5000/home/ConfiguredAction/123?value=5555
        public ActionResult<string> ConfiguredAction(string id, string value)
        {
            return $"Hello world! {id} - {value}";
        }
    }
}
