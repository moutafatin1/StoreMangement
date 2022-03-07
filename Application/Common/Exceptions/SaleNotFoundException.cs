using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions;
public class SaleNotFoundException : NotFoundException
{
    public SaleNotFoundException(int saleId) : base($"The Sale with id : {saleId} doesn't exist in the database")
    {
    }
}
