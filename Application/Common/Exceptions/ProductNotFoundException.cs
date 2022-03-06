using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions;
public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(int productId) : base($"The product with id : {productId} doesn't exist in the database")
    {
    }
}
