using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Product;
public record UpdateProductDto(int CategoryId, string Name, string Description, decimal UnitPrice);

