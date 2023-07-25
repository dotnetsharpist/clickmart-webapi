using Microsoft.AspNetCore.Http;

namespace ClickMart.Service.Dtos.Media;

public class ImageCreateDto
{
    public IFormFile File { get; set; } = default!;
}