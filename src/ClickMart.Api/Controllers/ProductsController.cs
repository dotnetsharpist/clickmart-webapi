using ClickMart.DataAccess.Interfaces.Products;
using ClickMart.DataAccess.Utils;
using ClickMart.Domain.Entities.Products;
using ClickMart.Service.Dtos.Products;
using ClickMart.Service.Interfaces.Common;
using ClickMart.Service.Interfaces.Products;
using ClickMart.Service.Validators.Dtos.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClickMart.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;
    private readonly IProductService _service;
    private IWebHostEnvironment _env;

    private readonly int maxPageSize = 30;

    public ProductsController(IProductRepository repository, IProductService service)
    {
        this._service = service;
        this._repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetByIdAsync(long productId)
            => Ok(await _service.GetByIdAsync(productId));

    [HttpGet("search")]
    public async Task<IActionResult> SearchAsync([FromQuery] string search, [FromQuery] int page = 1)
            => Ok(await _service.SearchAsync(search, new PaginationParams(page, maxPageSize)));

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] ProductsCreateDto dto)
    {
        var createValidator = new ProductsCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateAsync(long productId, [FromForm] ProductsUpdateDto dto)
    {
        var updateValidator = new ProductsUpdateValidator();
        var result = updateValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(productId, dto));
        else return BadRequest(result.Errors);
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteAsync(long productId)
            => Ok(await _service.DeleteAsync(productId));

    [HttpGet("byCategory/{category}")]
    public async Task<ActionResult<IList<Product>>> GetCarsByCategory(string category)
    {
        var products = await _repository.GetCarsByCategory(category.ToUpper());
        return Ok(products);
    }
}
