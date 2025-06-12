using AutoMapper;
using FinanceTracking.API.DTOs;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;

namespace FinanceTracking.API.Mappers;

public sealed class TransactionMapperProfile : Profile
{
    public TransactionMapperProfile()
    {
        CreateModelMapper();
        CreateDTOMapper();
    }

    private void CreateModelMapper()
    {
        CreateMap<TransactionEntity, TransactionModel>()
            .ReverseMap();
    }

    private void CreateDTOMapper()
    {
        CreateMap<TransactionModel, TransactionDTO>()
            .ReverseMap();

        CreateMap<CreateTransactionDTO, TransactionModel>();
        CreateMap<UpdateTransactionDTO, TransactionModel>();
    }
}