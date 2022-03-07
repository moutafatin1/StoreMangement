using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Sales.Queries;
using Microsoft.AspNetCore.Mvc;

namespace StoreMangement.API.Controllers;

[Route("api/sale")]
[ApiController]
public class SaleController : ControllerBase
{
    private readonly ISender _sender;

    public SaleController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetSales()
    {
        var sales = await _sender.Send(new GetSalesQuery(trackChanges: false));

        return Ok(sales);
    }
}
