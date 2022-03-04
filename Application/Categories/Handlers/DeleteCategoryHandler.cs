using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;

namespace Application.Categories.Handlers;
public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly IRepositoryManager _repository;

    public DeleteCategoryHandler(IRepositoryManager repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.Category.GetCategoryAsync(request.CategoryId, request.trackChanges);

        if (category is null)
            throw new CategoryNotFoundException(request.CategoryId);

        _repository.Category.DeleteCategory(category);
        await _repository.SaveAsync();

        return Unit.Value;
    }
}
