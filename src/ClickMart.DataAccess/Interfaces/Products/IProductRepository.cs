using ClickMart.DataAccess.Common.Interfaces;
using ClickMart.DataAccess.ViewModels.Products;
using ClickMart.Domain.Entities.Products;

namespace ClickMart.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product, Product>, 
    IGetAll<Product>, ISearchable<Product>
{
    public Task<int> SearchCountAsync(string search);

    public Task<IList<Product>> GetCarsByCategory(string category);
}
