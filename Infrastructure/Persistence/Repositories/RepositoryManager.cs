using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories;
public class RepositoryManager : IRepositoryManager
{
    private readonly ApplicationDbContext DbContext;
    private readonly Lazy<ICategoryRepository> _categoryRepository;
    private readonly Lazy<IProductRepository> _productRepository;
    private readonly Lazy<ISaleRepository> _saleRepository;

    public RepositoryManager(ApplicationDbContext applicationDbContext)
    {
        DbContext = applicationDbContext;
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(DbContext));
        _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(DbContext));
        _saleRepository = new Lazy<ISaleRepository>(() => new SaleRepository(DbContext));
    }


    public ICategoryRepository Category => _categoryRepository.Value;

    public IProductRepository Product => _productRepository.Value;

    public ISaleRepository Sale => _saleRepository.Value;

    public async Task SaveAsync() => await DbContext.SaveChangesAsync();
}
