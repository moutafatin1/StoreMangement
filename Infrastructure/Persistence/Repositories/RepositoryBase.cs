using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected ApplicationDbContext DbContext { get; set; }

    public RepositoryBase(ApplicationDbContext applicationDbContext)
    {
        DbContext = applicationDbContext;

    }

    public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? DbContext.Set<T>().AsNoTracking() : DbContext.Set<T>();



    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ?
          DbContext.Set<T>().Where(expression).AsNoTracking() :
          DbContext.Set<T>();


    public void Create(T entity) => DbContext.Set<T>().Add(entity);

    public void Update(T entity) => DbContext.Set<T>().Update(entity);

    public void Delete(T entity) => DbContext.Set<T>().Remove(entity);

}

