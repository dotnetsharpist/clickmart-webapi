using ClickMart.DataAccess.Common.Interfaces;
using ClickMart.Domain.Entities.Categories;

namespace ClickMart.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category, Category>, 
    IGetAll<Category>
{
        
}
