using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Products.Commands;
using Microsoft.AspNetCore.Mvc;

namespace StoreMangement.API.Controllers;

[Route("api/categories/{categoryId}/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ISender _sender;

    public ProductController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(int categoryId)
    {
        var products = await _sender.Send(new GetProductsForCategoryQuery(categoryId, TrackChanges: false));

        return Ok(products);

    }


    [HttpGet("{productId}", Name = "ProductById")]
    public async Task<IActionResult> GetProductById(int categoryId, int productId)
    {
        var product = await _sender.Send(new GetProductByIdQuery(categoryId, productId, TrackChanges: false));

        return Ok(product);
    }


    [HttpGet("~/api/products")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _sender.Send(new GetAllProductsQuery(trackChanges: false));

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(int categoryId, [FromBody] CreateProductDto productForCreation)
    {
        var product = await _sender.Send(new CreateProductCommand(categoryId, TrackChanges: false, productForCreation));

        return CreatedAtRoute("ProductById", new { categoryId, productId = product.Id }, product);
    }

}
