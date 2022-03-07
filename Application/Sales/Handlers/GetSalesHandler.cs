using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Handlers;
public class GetSalesHandler : IRequestHandler<GetSalesQuery, IEnumerable<SaleDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetSalesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<SaleDto>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
    {
        var sales = await _repository.Sale.GetAllSales(request.trackChanges);

        var salesDto = _mapper.Map<IEnumerable<SaleDto>>(sales);

        return salesDto;
    }
}
