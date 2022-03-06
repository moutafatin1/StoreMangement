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
    private readonly Helper _helper;

    public DeleteCategoryHandler(IRepositoryManager repository, Helper helper)
    {
        _repository = repository;
        _helper = helper;
    }
    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _helper.GetCategoryAndCheckIfExists(request.CategoryId, request.TrackChanges);


        _repository.Category.DeleteCategory(category);
        await _repository.SaveAsync();

        return Unit.Value;
    }
}
