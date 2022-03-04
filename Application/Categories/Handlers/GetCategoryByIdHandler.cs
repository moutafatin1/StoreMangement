using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;

namespace Application.Categories.Handlers;
public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetCategoryByIdHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.Category.GetCategoryAsync(request.categoryId, request.trackChanges);

        if (category == null)
            throw new CategoryNotFoundException(request.categoryId);

        var categoryDto = _mapper.Map<CategoryDto>(category);
        return categoryDto;
    }
}
