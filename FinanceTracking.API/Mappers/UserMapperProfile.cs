using AutoMapper;
using FinanceTracking.API.DTOs;
using FinanceTracking.API.Mappers.Resolvers;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;

namespace FinanceTracking.API.Mappers;

public sealed class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateModelMapper();
        CreateDTOMapper();
    }

    private void CreateModelMapper()
    {
        CreateMap<UserEntity, UserModel>()
            .PreserveReferences()
            .MaxDepth(1)
            .ForMember(d => d.Status, opt => opt.MapFrom<UserStatusResolver>())
            .ReverseMap();
    }

    private void CreateDTOMapper()
    {
        CreateMap<UserModel, UserDTO>()
            .ReverseMap();
    }
}
