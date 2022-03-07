using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Sale;
public record class SaleDto(int Id, DateTime SaleDate, decimal TotalPrice, ICollection<SaleDetailsDto> SaleDetails);

