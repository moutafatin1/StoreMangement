using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;
public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
{
    public SaleRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<IEnumerable<Sale>> GetAllSales(bool trackChanges) =>
            await FindAll(trackChanges).Include(s => s.SaleDetails).ToListAsync();

    public void CreateSale(Sale sale) => Create(sale);



}
