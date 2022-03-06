using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Product;
public record CreateProductDto(string Name, string Description, decimal UnitPrice);
