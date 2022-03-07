using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories;
public interface IProductRepository
{
    Task<List<Product>> GetProductsForCategoryAsync(int categoryId, bool trackChanges);
    Task<Product?> GetProductByIdAsync(int categoryId, int productId, bool trackChanges);
    Task<List<Product>> GetAllProducts(bool trackChanges);
    void CreateProductForCategory(int categoryId, Product product);
    void DeleteProduct(Product product);
}
