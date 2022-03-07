using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Product;

namespace Contracts.Category
{
    public record CategoryDto
    {
        public int Id { get; set; }

        public string? Name { get; init; }

        public string? Description { get; init; }

    }
}
