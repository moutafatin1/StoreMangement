using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;

namespace Application.Products.Handlers;
public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly Helper _helper;

    public GetProductByIdHandler(IRepositoryManager repository, IMapper mapper, Helper helper)
    {
        _repository = repository;
        _mapper = mapper;
        _helper = helper;
    }
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        await _helper.CheckIfCategoryExists(request.CategoryId, request.TrackChanges);

        var product = await _helper.GetProductAndCheckIfExists(request.CategoryId, request.ProductId, request.TrackChanges);

        var productDto = _mapper.Map<ProductDto>(product);

        return productDto;
    }
}
