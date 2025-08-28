using MongoDB.Driver;
using Mint.Domain.Models;
using Mint.Application.DTOs;
using Mint.Application.Mappings;
using Mint.Application.Interfaces;

namespace Mint.Application.Services
{
    /// <summary>
    /// Service for managing transactions.
    /// </summary>
    /// <param name="database"> MongoDB Database </param>
    public class TransactionService(IMongoDatabase database) : ITransactionService
    {
        /// <summary>
        /// The collection of transactions from MongoDB.
        /// </summary>
        private readonly IMongoCollection<Transaction> _transactionCollection = database.GetCollection<Transaction>("Transactions");

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _transactionCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _transactionCollection.Find(transaction => transaction.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TransactionDto> CreateAsync(TransactionDto transaction)
        {
            await _transactionCollection.InsertOneAsync(transaction.ToEntity());
            return transaction;
        }

        public async Task<TransactionDto?> UpdateAsync(int id, TransactionDto updatedTransaction)
        {
            var transaction = await _transactionCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
            if (transaction is null)
            {
                return null;
            }
            transaction.Name = updatedTransaction.Name;
            transaction.Amount = updatedTransaction.Amount;
            transaction.Category = updatedTransaction.Category;
            transaction.UpdatedAt = DateTime.UtcNow;

            await _transactionCollection.ReplaceOneAsync(t => t.Id == id, transaction);
            return transaction.ToDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _transactionCollection.DeleteOneAsync(t => t.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
