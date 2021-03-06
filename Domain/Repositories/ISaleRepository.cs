using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories;
public interface ISaleRepository
{
    void CreateSale(Sale sale);
    Task<Sale?> GetSale(int saleId, bool trackChanges);
    Task<IEnumerable<Sale>> GetAllSales(bool trackChanges);
}
