using ClickMart.DataAccess.Utils;
using ClickMart.Domain.Entities.Products;
using ClickMart.Service.Dtos.Products;

namespace ClickMart.Service.Interfaces.Products;

public interface IProductService
{
    public Task<bool> CreateAsync(ProductsCreateDto dto);

    public Task<bool> DeleteAsync(long productId);

    public Task<long> CountAsync();

    public Task<IList<Product>> GetAllAsync(PaginationParams @params);

    public Task<Product> GetByIdAsync(long productId);

    public Task<bool> UpdateAsync(long productId, ProductsUpdateDto dto);

    public Task<IList<Product>> SearchAsync(string search, PaginationParams @params);

    public Task<int> SearchCountAsync(string search);

}
