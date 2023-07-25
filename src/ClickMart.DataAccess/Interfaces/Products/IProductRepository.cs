using ClickMart.DataAccess.Common.Interfaces;
using ClickMart.DataAccess.ViewModels.Products;
using ClickMart.Domain.Entities.Products;

namespace ClickMart.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product, ProductViewModel>, 
    IGetAll<ProductViewModel>, ISearchable<ProductViewModel>
{

}
