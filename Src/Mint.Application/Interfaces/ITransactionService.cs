using Mint.Domain.Models;
using Mint.Application.DTOs;
using MongoDB.Bson;

namespace Mint.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<TransactionDto> CreateAsync(TransactionDto transaction);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Transaction>> GetAllAsync();
        Task<Transaction?> GetByIdAsync(Guid id);
        Task<TransactionDto?> UpdateAsync(Guid id, TransactionDto updatedTransaction);
    }
}
