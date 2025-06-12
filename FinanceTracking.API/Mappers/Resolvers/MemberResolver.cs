using AutoMapper;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;

namespace FinanceTracking.API.Mappers.Resolvers;

public sealed class MemberStatusResolver : IValueResolver<MemberEntity, MemberModel, MemberStatus>
{
    public MemberStatus Resolve(MemberEntity source, MemberModel destination, MemberStatus destMember, ResolutionContext context) =>
        source.IsActive switch
        {
            true => MemberStatus.Active,
            false => MemberStatus.Inactive
        };
}
