namespace Mint.Application.Mappings
{
    using Mint.Domain.Models;
    using Mint.Application.DTOs;

    /// <summary>
    /// Extension methods for mapping between Budget and BudgetDto.
    /// </summary>
    public static class BudgetMappingExtension
    {
        /// <summary>
        /// Maps a BudgetDto to a Budget entity.
        /// </summary>
        /// <param name="dto"> The BudgetDto to be mapped </param>
        /// <returns>A Budget Entity <see cref="Budget"/> </returns>
        public static Budget ToEntity(this BudgetDto dto)
        {
            return new Budget
            {
                Name = dto.Name,
                Income = dto.Income,
                Expense = dto.Expense,
                Balance = dto.Balance,
                Month = dto.Month,
                CreatedAt = dto.CreatedAt
            };
        }

        /// <summary>
        /// Maps a Budget entity to a BudgetDto.
        /// </summary>
        /// <param name="entity"> The Budget entity to be mapped </param>
        /// <returns> A BudgetDto <see cref="BudgetDto"></returns>
        public static BudgetDto ToDto(this Budget entity)
        {
            return new BudgetDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Income = entity.Income,
                Expense = entity.Expense,
                Balance = entity.Balance,
                Month = entity.Month,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}