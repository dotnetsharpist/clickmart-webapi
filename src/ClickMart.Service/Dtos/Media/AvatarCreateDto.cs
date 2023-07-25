using Microsoft.AspNetCore.Http;

namespace ClickMart.Service.Dtos.Media;

public class AvatarCreateDto
{
    public IFormFile Avatar { get; set; } = default!;
}
