using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Products.Handlers;
public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly Helper _helper;

    public CreateProductHandler(IRepositoryManager repository, IMapper mapper, Helper helper)
    {
        _repository = repository;
        _mapper = mapper;
        _helper = helper;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _helper.CheckIfCategoryExists(request.CategoryId, request.TrackChanges);

        var productEnitity = _mapper.Map<Product>(request.Product);

        _repository.Product.CreateProductForCategory(request.CategoryId, productEnitity);
        await _repository.SaveAsync();

        var productDto = _mapper.Map<ProductDto>(productEnitity);

        return productDto;
    }
}
