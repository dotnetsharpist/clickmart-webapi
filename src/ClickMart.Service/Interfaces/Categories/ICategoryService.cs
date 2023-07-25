using ClickMart.DataAccess.Utils;
using ClickMart.Domain.Entities.Categories;
using ClickMart.Service.Dtos.Categories;

namespace ClickMart.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<bool> CreateAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<long> CountAsync();

    public Task<IList<Category>> GetAllAsync(PaginationParams @params);

    public Task<Category> GetByIdAsync(long categoryId);

    public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto);
}
