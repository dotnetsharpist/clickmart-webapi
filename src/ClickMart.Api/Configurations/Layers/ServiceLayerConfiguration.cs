using ClickMart.Service.Interfaces.Auth;
using ClickMart.Service.Interfaces.Categories;
using ClickMart.Service.Interfaces.Common;
using ClickMart.Service.Interfaces.Companies;
using ClickMart.Service.Interfaces.Notifcations;
using ClickMart.Service.Services.Auth;
using ClickMart.Service.Services.Categories;
using ClickMart.Service.Services.Common;
using ClickMart.Service.Services.Companies;
using ClickMart.Service.Services.Notifications;

namespace ClickMart.WebApi.Configurations.Layers;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        //-> DI containers, IoC containers
        builder.Services.AddScoped<IFileService, FileService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IPaginator, Paginator>();
        builder.Services.AddSingleton<ISmsSender, SmsSender>();
    }
}
