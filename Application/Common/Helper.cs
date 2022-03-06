using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common;
public class Helper
{
    private readonly IRepositoryManager _repository;

    public Helper(IRepositoryManager repository)
    {
        _repository = repository;
    }

    public async Task CheckIfCategoryExists(int categoryId, bool trackChanges)
    {
        var category = await _repository.Category.GetCategoryAsync(categoryId, trackChanges);
        if (category is null)
            throw new CategoryNotFoundException(categoryId);
    }


    public async Task<Product> GetProductAndCheckIfExists(int categoryId, int productId, bool trackChanges)
    {
        var product = await _repository.Product.GetProductByIdAsync(categoryId, productId, trackChanges);
        if (product is null)
            throw new ProductNotFoundException(productId);

        return product;
    }
}
