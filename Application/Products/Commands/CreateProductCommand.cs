using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands;
public sealed record CreateProductCommand(int CategoryId, bool TrackChanges, CreateProductDto Product) : IRequest<ProductDto>;

