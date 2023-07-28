using ClickMart.Service.Common.Helpers;
using ClickMart.Service.Dtos.Products;
using FluentValidation;

namespace ClickMart.Service.Validators.Dtos.Products;

public class ProductsUpdateValidator : AbstractValidator<ProductsUpdateDto>
{
    public ProductsUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!")
            .MinimumLength(3).WithMessage("Name must be more than 3 characters")
            .MaximumLength(50).WithMessage("Name must be less than 50 characters");

        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!")
            .MinimumLength(20).WithMessage("Description must be more than 20 characters");

        int maxImageSizeMb = 3;
        RuleFor(dto => dto.Image).NotNull().NotEmpty().WithMessage("Image field is required!");
        RuleFor(dto => dto.Image.Length).LessThan(maxImageSizeMb * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMb} MB");
        RuleFor(dto => dto.Image.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        }
        ).WithMessage("Please choose an image!");
    }
}
