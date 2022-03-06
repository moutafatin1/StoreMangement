using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StoreMangement.API.Controllers;

[Route("api/categories")]
[ApiController]

public class CategoryController : ControllerBase
{
    private readonly ISender _sender;

    public CategoryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _sender.Send(new GetCategoriesQuery(trackChanges: false));

        return Ok(categories);
    }

    [HttpGet("{categoryId:int}", Name = "CategoryById")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var category = await _sender.Send(new GetCategoryByIdQuery(categoryId, trackChanges: false));

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryForCreation)
    {
        if (categoryForCreation is null)
            return BadRequest("CategoryForCreation object is null");

        var category = await _sender.Send(new CreateCategoryCommand(categoryForCreation));

        return CreatedAtRoute("CategoryById", new { categoryId = category.Id }, category);
    }


    [HttpPut("{categoryId:int}")]
    public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] UpdateCategoryDto categoryForUpdate)
    {
        if (categoryForUpdate is null)
            return BadRequest("CategoryForUpdate object is null");

        await _sender.Send(new UpdateCategoryCommand(categoryId, categoryForUpdate, TrackChanges: true));

        return NoContent();
    }

    [HttpDelete("{categoryId:int}")]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        await _sender.Send(new DeleteCategoryCommand(categoryId, trackChanges: false));

        return NoContent();
    }

}
