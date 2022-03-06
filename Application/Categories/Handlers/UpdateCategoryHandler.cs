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
    private readonly Helper _helper;

    public UpdateCategoryHandler(IRepositoryManager repository, IMapper mapper, Helper helper)
    {
        _repository = repository;
        _mapper = mapper;
        _helper = helper;
    }
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryEntity = await _helper.GetCategoryAndCheckIfExists(request.CategoryId, request.TrackChanges);

        _mapper.Map(request.Category, categoryEntity);

        await _repository.SaveAsync();

        return Unit.Value;


    }
}
