using AutoMapper;
using FinanceTracking.API.DTOs;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;

namespace FinanceTracking.API.Mappers;

public sealed class AccountTypeMapperProfile : Profile
{
    public AccountTypeMapperProfile()
    {
        CreateModelMapper();
        CreateDTOMapper();
    }

    private void CreateModelMapper()
    {
        CreateMap<AccountTypeEntity, AccountTypeModel>()
            .ReverseMap();
    }

    private void CreateDTOMapper()
    {
        CreateMap<AccountTypeModel, AccountTypeDTO>()
            .ReverseMap();

        CreateMap<CreateAccountTypeDTO, AccountTypeModel>();
        CreateMap<UpdateAccountTypeDTO, AccountTypeModel>();
    }
}