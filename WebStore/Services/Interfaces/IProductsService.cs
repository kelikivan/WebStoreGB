using WebStore.Domain.Entities;

namespace WebStore.Services.Interfaces
{
	public interface IProductsService
	{
		IEnumerable<Section> GetSections();
		IEnumerable<Brand> GetBrands();
	}
}
