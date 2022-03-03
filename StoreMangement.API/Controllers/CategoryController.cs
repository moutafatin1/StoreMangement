using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Categories.Queries;
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


}
