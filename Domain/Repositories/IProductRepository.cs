using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories;
public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync(int categoryId, bool trackChanges);
    Task<Product?> GetProductByIdAsync(int categoryId, int productId, bool trackChanges);
    void CreateProductForCategory(int categoryId, Product product);
    void DeleteProduct(Product product);
}
