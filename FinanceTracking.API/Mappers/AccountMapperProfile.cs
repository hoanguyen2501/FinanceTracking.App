using AutoMapper;
using FinanceTracking.API.DTOs;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;

namespace FinanceTracking.API.Mappers;

public sealed class AccountMapperProfile : Profile
{
    public AccountMapperProfile()
    {
        CreateModelMapper();
        CreateDTOMapper();
    }

    private void CreateModelMapper()
    {
        CreateMap<AccountEntity, AccountModel>()
            .ReverseMap();
    }

    private void CreateDTOMapper()
    {
        CreateMap<AccountModel, AccountDTO>()
            .ReverseMap();

        CreateMap<CreateAccountDTO, AccountModel>();
        CreateMap<UpdateAccountDTO, AccountModel>();
    }
}