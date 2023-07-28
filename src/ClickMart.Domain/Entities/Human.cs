﻿using System.ComponentModel.DataAnnotations;

namespace ClickMart.Domain.Entities;

public abstract class Human : Auditable
{
    [MaxLength(50)]
    public string FirstName { get; set; } = String.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = String.Empty;

    [MaxLength(9)]
    public string PassportSeriaNumber { get; set; } = String.Empty;

    public bool IsMale { get; set; }

    public DateTime BirthDate { get; set; }

    public string Country { get; set; } = String.Empty;

    public string Region { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;
}
