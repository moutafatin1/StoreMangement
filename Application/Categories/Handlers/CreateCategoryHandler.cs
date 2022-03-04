using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Categories.Handlers;
public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateCategoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryEntity = _mapper.Map<Category>(request.category);

        _repository.Category.CreateCategory(categoryEntity);
        await _repository.SaveAsync();

        var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);

        return categoryDto;
    }
}
