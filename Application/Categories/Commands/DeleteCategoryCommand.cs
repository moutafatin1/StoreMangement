﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands;
public record DeleteCategoryCommand(int CategoryId, bool trackChanges) : IRequest;

