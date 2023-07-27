using ClickMart.DataAccess.Interfaces;
using ClickMart.DataAccess.Interfaces.Categories;
using ClickMart.DataAccess.Repositories.Categories;
using ClickMart.DataAccess.Utils;
using ClickMart.Domain.Entities.Categories;
using ClickMart.Domain.Exceptions.Categories;
using ClickMart.Domain.Exceptions.Files;
using ClickMart.Service.Common.Helpers;
using ClickMart.Service.Dtos.Categories;
using ClickMart.Service.Interfaces.Categories;
using ClickMart.Service.Interfaces.Common;

namespace ClickMart.Service.Services.Categories;

public class CategoryService : ICategoryService
{

    private readonly IFileService _fileService;
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository categoryRepository,
        IFileService fileService)
    {
        this._repository = categoryRepository;
        this._fileService = fileService;
    }

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        var categories = await _repository.GetAllAsync(@params);
        return categories;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        string imagePath = await _fileService.UploadImageAsync(dto.Image);
        Category category = new Category
        {
            ImagePath = imagePath,
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };

        var result = await _repository.CreateAsync(category);

        return result > 0;
    }

    public async Task<bool> DeleteAsync(long categoryId)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        var result = await _fileService.DeleteImageAsync(category.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _repository.DeleteAsync(categoryId);
        return dbResult > 0;
    }

    public async Task<Category> GetByIdAsync(long categoryId)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();
        return category;
    }

    public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        var category = await _repository.GetByIdAsync(categoryId);
        if (category is null) throw new CategoryNotFoundException();

        category.Name = dto.Name;
        category.Description = dto.Description;

        if (dto.Image is not null)
        {
            var deleteresult = await _fileService.DeleteImageAsync(category.ImagePath);
            if (deleteresult is false) throw new ImageNotFoundException();

            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            category.ImagePath = newImagePath;
        }

        category.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(categoryId,category);

        return dbResult > 0;
    }
}
