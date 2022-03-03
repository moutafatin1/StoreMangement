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

    public RepositoryManager(ApplicationDbContext applicationDbContext)
    {
        DbContext = applicationDbContext;
        _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(DbContext));
    }


    public ICategoryRepository Category => _categoryRepository.Value;

    public async Task SaveAsync() => await DbContext.SaveChangesAsync();
}
