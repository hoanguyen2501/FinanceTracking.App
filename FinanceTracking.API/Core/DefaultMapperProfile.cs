using AutoMapper;
using FinanceTracking.API.DTOs;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;

namespace FinanceTracking.API.Core
{
    public sealed class DefaultMapperProfile : Profile
    {
        private void CreateModelMapper()
        {
            CreateMap<CategoryEntity, CategoryModel>()
                .ReverseMap();
        }

        private void CreateDTOMapper()
        {
            CreateMap<CategoryModel, CategoryDTO>()
                .ReverseMap();

            CreateMap<CreateCategoryDTO, CategoryModel>();
        }

        public DefaultMapperProfile()
        {
            CreateModelMapper();
            CreateDTOMapper();
        }
    }
}
