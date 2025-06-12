using AutoMapper;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;

namespace FinanceTracking.API.Mappers.Resolvers
{
    public sealed class UserStatusResolver : IValueResolver<UserEntity, UserModel, UserStatus>
    {
        public UserStatus Resolve(UserEntity source, UserModel destination, UserStatus destMember, ResolutionContext context) =>
            source.IsActive switch
            {
                true => UserStatus.Active,
                false => UserStatus.Inactive
            };
    }
}