using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IProductsService _productsService;
		public ProductsController(IProductsService productsService)
		{
			_productsService = productsService;
		}

		public IActionResult Index(int? brandId, int? sectionId)
		{
			var filter = new ProductFilter
			{
				SectionId = sectionId,
				BrandId = brandId
			};

			var products = _productsService.GetProducts(filter);

			var catalog_model = new CatalogViewModel
			{
				BrandId = brandId,
				SectionId = sectionId,
				Products = products
					.OrderBy(p => p.BrandId)
					.Select(p => new ProductViewModel
					{
						Id = p.Id,
						Name = p.Name,
						Price = p.Price,
						ImageUrl = p.ImageUrl,
					}),
			};

			return View(catalog_model);
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
