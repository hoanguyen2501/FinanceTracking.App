using AutoMapper;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;

namespace FinanceTracking.API.Mappers.Resolvers;

public sealed class CategoryTypeResolver : IValueResolver<CategoryEntity, CategoryModel, CategoryType>
{
    public CategoryType Resolve(CategoryEntity source, CategoryModel destination, CategoryType destMember, ResolutionContext context)
    {
        var type = source.Type switch
        {
            "I" => CategoryType.Income,
            "X" => CategoryType.Expense,
            _ => throw new Exception("Category Type was not found")
        };

        return type;
    }
}