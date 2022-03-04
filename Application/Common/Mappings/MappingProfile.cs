using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();

        CreateMap<CreateCategoryDto, Category>();

        CreateMap<UpdateCategoryDto, Category>();
    }
}
