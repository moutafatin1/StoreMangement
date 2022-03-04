using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;

namespace Application.Categories.Handlers;
public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateCategoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryEntity = await _repository.Category.GetCategoryAsync(request.CategoryId, request.TrackChanges);

        if (categoryEntity is null)
            throw new CategoryNotFoundException(request.CategoryId);

        _mapper.Map(request.Category, categoryEntity);

        await _repository.SaveAsync();

        return Unit.Value;


    }
}
