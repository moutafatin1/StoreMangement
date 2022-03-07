﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Product;

namespace Contracts.Sale;
public record CreateSaleDto(DateTime SaleDate, decimal TotalPrice, ICollection<CreateSaleDetailsDto> SaleDetails);

