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

        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();

        CreateMap<Sale, SaleDto>();
        CreateMap<SaleDetails, SaleDetailsDto>();
        CreateMap<CreateSaleDto, Sale>();
        CreateMap<CreateSaleDetailsDto, SaleDetails>();

    }
}
