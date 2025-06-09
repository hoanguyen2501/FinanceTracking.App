using AutoMapper;
using FinanceTracking.DAL.Entities;
using FinanceTracking.DAL.Models;
using static FinanceTracking.DAL.Models.CategoryModel;

namespace FinanceTracking.API.Mappers.Resolvers;

public sealed class CategeryTypeResolver : IValueResolver<CategoryEntity, CategoryModel, CategoryType>,
                                        IValueResolver<CategoryModel, CategoryEntity, string>
{
    public CategoryType Resolve(CategoryEntity source, CategoryModel destination, CategoryType destMember, ResolutionContext context) =>
        source.Type switch
        {
            CategoryEntity.IncomeType => CategoryType.Income,
            CategoryEntity.ExpenseType => CategoryType.Expense,
            _ => throw new ArgumentOutOfRangeException(nameof(source.Type), source.Type, null)
        };

    public string Resolve(CategoryModel source, CategoryEntity destination, string destMember, ResolutionContext context) =>
        source.Type switch
        {
            CategoryType.Income => CategoryEntity.IncomeType,
            CategoryType.Expense => CategoryEntity.ExpenseType,
            _ => throw new ArgumentOutOfRangeException(nameof(source.Type), source.Type, null)
        };
}
