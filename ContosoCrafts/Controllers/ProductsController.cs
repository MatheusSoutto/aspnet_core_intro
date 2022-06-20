using ContosoCrafts.Models;
using ContosoCrafts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    public ProductsController(JsonFileProductService service)
    {
        this.Service = service;
    }

    public JsonFileProductService Service { get; }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        
        return this.Service.GetProducts();
    }

    [Route("rate")]
    [HttpPatch]
    public IActionResult AddRating(
        [FromQuery] string productId, 
        [FromQuery] int rating
    )
    {
        Service.AddRating(productId, rating);
        return Ok();
    }
}