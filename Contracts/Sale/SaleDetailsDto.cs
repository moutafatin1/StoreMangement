using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Sale;
public record SaleDetailsDto(int Id, int ProductId, int Quantity, decimal UnitPrice, int SaleId);
