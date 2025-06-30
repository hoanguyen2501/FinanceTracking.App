using AutoMapper;
using FinanceTracking.API.DTOs;
using FinanceTracking.API.Mappers.Resolvers;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;

namespace FinanceTracking.API.Mappers;

public sealed class MemberMapperProfile : Profile
{
    public MemberMapperProfile()
    {
        CreateModelMapper();
        CreateDTOMapper();
    }

    private void CreateModelMapper()
    {
        CreateMap<MemberEntity, MemberModel>()
            .PreserveReferences()
            .MaxDepth(1)
            .ForMember(d => d.Status, opt => opt.MapFrom<MemberStatusResolver>())
            .ReverseMap();
    }

    private void CreateDTOMapper()
    {
        CreateMap<MemberModel, MemberDTO>()
            .PreserveReferences()
            .ReverseMap();

        CreateMap<CreateMemberDTO, MemberModel>();
        CreateMap<UpdateMemberDTO, MemberModel>();
    }
}
