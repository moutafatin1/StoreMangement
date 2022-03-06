

namespace Application.Products.Handlers;
public class GetProductsForCategoryHandler : IRequestHandler<GetProductsForCategoryQuery, IEnumerable<ProductDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly Helper _helper;

    public GetProductsForCategoryHandler(IRepositoryManager repository, IMapper mapper, Helper helper)
    {
        _repository = repository;
        _mapper = mapper;
        _helper = helper;
    }
    public async Task<IEnumerable<ProductDto>> Handle(GetProductsForCategoryQuery request, CancellationToken cancellationToken)
    {

        await _helper.CheckIfCategoryExists(request.CategoryId, request.TrackChanges);

        var products = await _repository.Product.GetProductsAsync(request.CategoryId, request.TrackChanges);

        var productsDto = _mapper.Map<List<ProductDto>>(products);

        return productsDto;
    }
}
