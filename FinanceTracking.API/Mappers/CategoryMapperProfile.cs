using AutoMapper;
using FinanceTracking.API.DTOs;
using FinanceTracking.API.Mappers.Resolvers;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;

namespace FinanceTracking.API.Mappers;

public sealed class CategoryMapperProfile : Profile
{
    public CategoryMapperProfile()
    {
        CreateModelMapper();
        CreateDTOMapper();
    }

    private void CreateModelMapper()
    {
        CreateMap<CategoryEntity, CategoryModel>()
            .PreserveReferences()
            .MaxDepth(1)
            .ForMember(d => d.Type, opt => opt.MapFrom<CategoryTypeResolver>())
            .ReverseMap();
    }

    private void CreateDTOMapper()
    {
        CreateMap<CategoryModel, CategoryDTO>()
            .PreserveReferences()
            .ReverseMap();

        CreateMap<CreateCategoryDTO, CategoryModel>();
        CreateMap<UpdateCategoryDTO, CategoryModel>();
    }
}