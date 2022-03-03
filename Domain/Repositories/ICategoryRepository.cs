using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);

        Task<Category> GetCategoryAsync(int categoryId, bool trackChanges);

        void CreateCategory(Category category);

        void DeleteCategory(Category category);

        //void UpdateCategory(Category category);
    }
}
