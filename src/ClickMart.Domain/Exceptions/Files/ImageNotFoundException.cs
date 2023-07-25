﻿using System.Runtime.CompilerServices;

namespace ClickMart.Domain.Exceptions.Files;

public class ImageNotFoundException : NotFoundException
{
    public ImageNotFoundException()
    {
        this.TitleMessage = "Image not found!";
    }
}