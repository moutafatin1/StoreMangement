using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Commands;
public sealed record CreateSaleCommand(CreateSaleDto SaleForCreation) : IRequest<SaleDto>;
