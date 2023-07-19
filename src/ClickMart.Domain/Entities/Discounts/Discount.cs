using System.ComponentModel.DataAnnotations;

namespace ClickMart.Domain.Entities.Discounts;

public class Discount : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;


}
