

namespace Application.Categories.Handlers;
public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly Helper _helper;

    public GetCategoryByIdHandler(IRepositoryManager repository, IMapper mapper, Helper helper)
    {
        _repository = repository;
        _mapper = mapper;
        _helper = helper;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _helper.GetCategoryAndCheckIfExists(request.CategoryId, request.TrackChanges);

        var categoryDto = _mapper.Map<CategoryDto>(category);

        return categoryDto;
    }
}
