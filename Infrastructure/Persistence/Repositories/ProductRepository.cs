using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;
public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<List<Product>> GetProductsForCategoryAsync(int categoryId, bool trackChanges) =>
        await FindByCondition(p => p.CategoryId.Equals(categoryId), trackChanges).ToListAsync();


    public async Task<Product?> GetProductByIdAsync
        (int categoryId, int productId, bool trackChanges) =>
                 await FindByCondition(p => p.CategoryId.Equals(categoryId) && p.Id.Equals(productId), trackChanges).FirstOrDefaultAsync();



    public async Task<List<Product>> GetAllProducts(bool trackChanges) =>
        await FindAll(trackChanges).ToListAsync();


    public void CreateProductForCategory(int categoryId, Product product)
    {
        product.CategoryId = categoryId;
        Create(product);
    }

    public void DeleteProduct(Product product) => Delete(product);
}
