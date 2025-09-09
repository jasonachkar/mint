using Mint.Application.DTOs;

namespace Mint.Application.Interfaces
{
    public interface IBudgetService
    {
        Task<BudgetDto> CreateAsync(BudgetDto budgetDto);
        Task<bool> DeleteAsync(Guid id);
        Task<List<BudgetDto>> GetAllAsync();
        Task<BudgetDto?> GetByIdAsync(Guid id);
        Task<BudgetDto?> UpdateAsync(Guid id, BudgetDto updatedBudgetDto);
    }
}