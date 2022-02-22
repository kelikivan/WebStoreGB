using Microsoft.AspNetCore.Mvc;
using WebStore.Services.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Components
{
	public class BrandsViewComponent : ViewComponent
	{
		private readonly IProductsService _productsService;
		public BrandsViewComponent(IProductsService productsService)
		{
			_productsService = productsService;
		}

		public IViewComponentResult Invoke()
		{
			return View(GetBrands());
		}

		private IEnumerable<BrandViewModel> GetBrands() =>
			_productsService.GetBrands()
				.OrderBy(b => b.Order)
				.Select(b => new BrandViewModel
				{
					Id = b.Id,
					Name = b.Name,
				});
	}
}
