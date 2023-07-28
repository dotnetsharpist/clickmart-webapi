using ClickMart.DataAccess.Interfaces.Products;
using ClickMart.DataAccess.Utils;
using ClickMart.Domain.Entities.Products;
using ClickMart.Domain.Exceptions.Files;
using ClickMart.Domain.Exceptions.Products;
using ClickMart.Service.Common.Helpers;
using ClickMart.Service.Dtos.Products;
using ClickMart.Service.Interfaces.Common;
using ClickMart.Service.Interfaces.Products;
using ClickMart.Service.Services.Common;

namespace ClickMart.Service.Services.Products;

public class ProductService : IProductService
{
    private IProductRepository _repository;
    private IFileService _service;

    public ProductService(IProductRepository repository, IFileService service)
    {
        this._repository = repository;
        this._service = service;
    }

    public async Task<long> CountAsync()
        => await _repository.CountAsync();

    public async Task<bool> CreateAsync(ProductsCreateDto dto)
    {
        string imagepath = await _service.UploadImageAsync(dto.Image);

        Product product = new Product()
        {
            ImagePath = imagepath,
            Name = dto.Name,
            CategoryId = dto.CategoryId,
            Description = dto.Description,
            UnitPrice = dto.UnitPrice,
            CompanyId = dto.CompanyId,
        };
        var result = await _repository.CreateAsync(product);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long productId)
    {
        Product product = new Product();

        product = await _repository.GetByIdAsync(productId);
        if (product is null) throw new ProductNotFoundException();

        var result = await _service.DeleteImageAsync(product.ImagePath);
        if (result is false) throw new ProductNotFoundException();

        var dbResult = await _repository.DeleteAsync(productId);

        return dbResult > 0;
    }

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        var products = await _repository.GetAllAsync(@params);
        return products;
    }

    public async Task<Product> GetByIdAsync(long productId)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product is null) throw new ProductNotFoundException();

        else return product;
    }

    public async Task<IList<Product>> SearchAsync(string search, PaginationParams @params)
    {
        var products = await _repository.SearchAsync(search, @params);
        int count = await _repository.SearchCountAsync(search);
        return products;
    }

    public Task<int> SearchCountAsync(string search)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(long productId, ProductsUpdateDto dto)
    {
        var product = await _repository.GetByIdAsync(productId);
        if (product is null) throw new ProductNotFoundException();

        product.Name = dto.Name;
        product.Description = dto.Description;
        product.UnitPrice = dto.UnitPrice;
        product.CategoryId = dto.CategoryId;
        product.CompanyId = dto.CompanyId;

        if (dto.Image is not null)
        {
            var deleteRes = await _service.DeleteImageAsync(product.ImagePath);
            if (deleteRes is false) throw new ImageNotFoundException();
            string newImagePath = await _service.UploadImageAsync(dto.Image);
            product.ImagePath = newImagePath;
        }

        product.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(productId, product);
        return dbResult > 0;
    }
}
