﻿using Microsoft.AspNetCore.Http;

namespace ClickMart.Service.Dtos.Companies;

public class CompanyUpdateDto
{
    public string Name { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public IFormFile? Image { get; set; }
}
