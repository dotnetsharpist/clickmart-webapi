﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ClickMart.Service.Dtos.Categories;

public class CategoryCreateDto
{
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public IFormFile Image { get; set; } = default!;
}
