using AgileShop.DataAccess.Repositories.Users;
using ClickMart.DataAccess.Interfaces.Categories;
using ClickMart.DataAccess.Interfaces.Users;
using ClickMart.DataAccess.Repositories.Categories;
using ClickMart.DataAccess.Repositories.Companies;

namespace ClickMart.WebApi.Configurations.Layers;

public static class DataAccessConfiguration
{
    public static void ConfigureDataAccess(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}
