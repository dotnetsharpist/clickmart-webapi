using ClickMart.Service.Interfaces.Categories;
using ClickMart.DataAccess.Interfaces.Categories;
using ClickMart.DataAccess.Repositories.Categories;
using ClickMart.Service.Interfaces.Common;
using ClickMart.Service.Services.Common;
using ClickMart.Service.Services.Categories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();