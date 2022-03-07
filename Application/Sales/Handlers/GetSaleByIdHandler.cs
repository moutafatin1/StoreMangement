using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Handlers;
public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdQuery, SaleDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetSaleByIdHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<SaleDto> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
    {
        var sale = await _repository.Sale.GetSale(request.SaleId, request.TrackChanges);
        if (sale is null)
            throw new SaleNotFoundException(request.SaleId);

        var saleDto = _mapper.Map<SaleDto>(sale);
        return saleDto;
    }
}
