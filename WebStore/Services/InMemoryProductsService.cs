using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
	public class InMemoryProductsService : IProductsService
	{
		public IEnumerable<Brand> GetBrands()
		{
			return TestData.Brands;
		}

		public IEnumerable<Section> GetSections()
		{
			return TestData.Sections;
		}
	}
}
