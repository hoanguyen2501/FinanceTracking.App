using AutoMapper;
using FinanceTracking.API.DTOs;
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
            .ReverseMap();
    }

    private void CreateDTOMapper()
    {
        CreateMap<UserModel, UserDTO>()
            .ReverseMap();
    }
}
