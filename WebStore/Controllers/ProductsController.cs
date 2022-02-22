using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
	public class ProductsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Product()
		{
			return View();
		}

		public IActionResult Checkout()
		{
			return View();
		}

		public IActionResult Cart()
		{
			return View();
		}
	}
}
