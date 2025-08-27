using MongoDB.Driver;
using Mint.Domain.Models;

namespace Mint.Application.Services
{
    public class TransactionService
    {
        private readonly IMongoCollection<Transaction> _transactionCollection;
    }
}
