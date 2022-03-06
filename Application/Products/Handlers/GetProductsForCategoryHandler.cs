using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;

namespace Application.Products.Handlers;
public class GetProductsForCategoryHandler : IRequestHandler<GetProductsForCategoryQuery, IEnumerable<ProductDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetProductsForCategoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ProductDto>> Handle(GetProductsForCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.Category.GetCategoryAsync(request.CategoryId, request.TrackChanges);

        if (category is null)
            throw new CategoryNotFoundException(request.CategoryId);

        var products = await _repository.Product.GetProductsAsync(request.CategoryId, request.TrackChanges);

        var productsDto = _mapper.Map<List<ProductDto>>(products);

        return productsDto;
    }
}
