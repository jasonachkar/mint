using Mint.Application.DTOs;

namespace Mint.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateAsync(CategoryDto categoryDto);
        Task<bool> DeleteAsync(Guid id);
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(Guid id);
        Task<CategoryDto?> UpdateAsync(Guid id, CategoryDto updatedCategoryDto);
    }
}