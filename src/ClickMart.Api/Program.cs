using ClickMart.DataAccess.Interfaces.Products;
using ClickMart.DataAccess.Repositories.Products;
using ClickMart.Service.Interfaces.Common;
using ClickMart.Service.Interfaces.Products;
using ClickMart.Service.Services.Common;
using ClickMart.Service.Services.Products;
using ClickMart.WebApi.Configurations;
using ClickMart.WebApi.Configurations.Layers;
using ClickMart.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductsRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();
builder.ConfigureJwtAuth();
builder.ConfigureSwaggerAuth();
builder.ConfigureCORSPolicy();
builder.ConfigureDataAccess();
builder.ConfigureServiceLayer();

var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();