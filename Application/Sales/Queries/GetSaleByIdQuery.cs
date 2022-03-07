using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Sales.Queries;
public sealed record GetSaleByIdQuery(int SaleId, bool TrackChanges) : IRequest<SaleDto>;
