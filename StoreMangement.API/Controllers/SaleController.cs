using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Sales.Commands;
using Application.Sales.Queries;
using Contracts.Sale;
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

    [HttpGet("{saleId:int}", Name = "SaleById")]
    public async Task<IActionResult> GetSaleById(int saleId)
    {
        var sale = await _sender.Send(new GetSaleByIdQuery(saleId, TrackChanges: false));
        return Ok(sale);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleDto sale)
    {
        var CreatedSale = await _sender.Send(new CreateSaleCommand(sale));


        return CreatedAtRoute("SaleById", new { saleId = CreatedSale.Id }, CreatedSale);


    }
}
