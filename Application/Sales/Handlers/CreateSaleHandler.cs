using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Sales.Commands;
using Domain.Entities;

namespace Application.Sales.Handlers;
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, SaleDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<SaleDto> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {

        var saleEntity = _mapper.Map<Sale>(request.SaleForCreation);
        saleEntity.SaleDetails.ToList().ForEach(s => s.SaleId = saleEntity.Id);

        _repository.Sale.CreateSale(saleEntity);
        await _repository.SaveAsync();

        var saleDto = _mapper.Map<SaleDto>(saleEntity);

        return saleDto;






        //List<SaleDetails> ListOfSaleDetails = new();
        //var sale = new Sale();
        //sale.TotalPrice = ListOfSaleDetails.Sum(s => s.UnitPrice);

        //foreach (var product in request.SaleForCreation.products) {
        //    var saleDetails = new SaleDetails();

        //    saleDetails.ProductId = product.Id;
        //    saleDetails.Quantity = request.SaleForCreation.products.Select(p => p.Id.Equals(product.Id)).Count();
        //    saleDetails.UnitPrice = product.UnitPrice;
        //    saleDetails.SaleId = sale.Id;

        //    ListOfSaleDetails.Add(saleDetails);
        //}

        //sale.SaleDetails = ListOfSaleDetails;

        //_repository.Sale.CreateSale(sale);
        //await _repository.SaveAsync();

        //var saleDto = _mapper.Map<SaleDto>(sale);

        //return saleDto;
    }
}
