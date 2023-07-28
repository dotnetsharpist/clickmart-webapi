using ClickMart.Service.Common.Helpers;
using ClickMart.Service.Dtos.Products;
using FluentValidation;

namespace ClickMart.Service.Validators.Dtos.Products;

public class ProductsCreateValidator : AbstractValidator<ProductsCreateDto>
{
    public ProductsCreateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Product name is required!")
        .MaximumLength(30).WithMessage("Product name must be less than 30 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description is required!")
       .MaximumLength(100).WithMessage("Description must be less than 100 characters");

        RuleFor(dto => dto.UnitPrice).NotNull().NotEmpty().WithMessage("Car price is required!");

        When(dto => dto.Image is not null, () =>
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.Image!.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Image!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
