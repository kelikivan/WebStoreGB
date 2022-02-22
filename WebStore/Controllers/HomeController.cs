using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index([FromServices]IProductsService productService)
		{
			var products = productService.GetProducts()
				.OrderBy(p => p.BrandId)
				.Take(6)
				.Select(p => new ProductViewModel
				{
					Id = p.Id,
					Name = p.Name,
					Price = p.Price,
					ImageUrl = p.ImageUrl,
				});
			ViewBag.Products = products;

			//return Content("Данные из первого контроллера!");
			return View();
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
