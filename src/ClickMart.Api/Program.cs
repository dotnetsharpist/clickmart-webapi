using ClickMart.Service.Interfaces.Categories;
using ClickMart.DataAccess.Interfaces.Categories;
using ClickMart.DataAccess.Repositories.Categories;
using ClickMart.Service.Interfaces.Common;
using ClickMart.Service.Services.Common;
using ClickMart.Service.Services.Categories;
using ClickMart.DataAccess.Repositories.Companies;
using ClickMart.Service.Interfaces.Companies;
using ClickMart.Service.Services.Companies;
using ClickMart.WebApi.Configurations;
using ClickMart.WebApi.Configurations.Layers;
using ClickMart.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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


