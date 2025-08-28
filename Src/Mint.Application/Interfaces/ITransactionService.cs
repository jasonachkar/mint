using Mint.Domain.Models;
using Mint.Application.DTOs;

namespace Mint.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionDto> CreateAsync(TransactionDto transaction);
        Task<bool> DeleteAsync(int id);
        Task<List<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(int id);
        Task<TransactionDto?> UpdateAsync(int id, TransactionDto updatedTransaction);
    }
}
