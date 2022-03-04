using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }



    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
             .OrderBy(c => c.Name)
             .ToListAsync();


    public async Task<Category?> GetCategoryAsync(int categoryId, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(categoryId), trackChanges)
             .FirstOrDefaultAsync();



    public void CreateCategory(Category category) => Create(category);

    public void DeleteCategory(Category category) => Delete(category);


}


