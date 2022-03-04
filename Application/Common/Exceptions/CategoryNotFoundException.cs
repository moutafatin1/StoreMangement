using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions;
public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException(int categoryId) : base($"The category with id : {categoryId} doesn't exist in the database")
    {

    }


}
