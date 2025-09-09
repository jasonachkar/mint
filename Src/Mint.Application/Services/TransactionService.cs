using MongoDB.Driver;
using Mint.Domain.Models;
using Mint.Application.DTOs;
using Mint.Application.Mappings;
using Mint.Application.Interfaces;
using Microsoft.Extensions.Options;
using Mint.Application.Options;

namespace Mint.Application.Services
{
    /// <summary>
    /// Service for managing transactions.
    /// </summary>
    /// <param name="database"> MongoDB Database </param>
    public class TransactionService : ITransactionService
    {
        /// <summary>
        /// The collection of transactions from MongoDB.
        /// </summary>
        private readonly IMongoCollection<Transaction> _transactionCollection;

        public TransactionService(IOptions<MongoDatabaseOptions> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var database = mongoClient.GetDatabase(options.Value.Database);
            _transactionCollection = database.GetCollection<Transaction>(options.Value.CollectionName);
        }

        public async Task<List<TransactionDto>> GetAllAsync()
        {
            var transactions = await _transactionCollection.Find(_ => true).ToListAsync();
            return transactions.Select(transaction => transaction.ToDto()).ToList();
        }

        public async Task<TransactionDto?> GetByIdAsync(Guid id)
        {
            var transaction = await _transactionCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
            return transaction?.ToDto();
        }

        public async Task<TransactionDto> CreateAsync(TransactionDto transaction)
        {
            await _transactionCollection.InsertOneAsync(transaction.ToEntity());
            return transaction;
        }

        public async Task<TransactionDto?> UpdateAsync(Guid id, TransactionDto updatedTransaction)
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

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _transactionCollection.DeleteOneAsync(t => t.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
