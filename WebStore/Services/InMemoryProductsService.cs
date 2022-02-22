using WebStore.Data;
using WebStore.Domain;
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

		public IEnumerable<Product> GetProducts(ProductFilter? filter = null)
		{
			IEnumerable<Product> query = TestData.Products;

			if (filter != null)
			{
				if (filter.SectionId != null)
				{
					query = query.Where(p => p.SectionId == filter.SectionId);
				}

				if (filter.BrandId != null)
				{
					query = query.Where(p => p.SectionId == filter.BrandId);
				}
			}

			return query;
		}
	}
}
