using Microsoft.Extensions.Options;
using Mint.Application.DTOs;
using Mint.Application.Interfaces;
using Mint.Application.Mappings;
using Mint.Application.Options;
using Mint.Domain.Models;
using MongoDB.Driver;

namespace Mint.Application.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IMongoCollection<Budget> _budgetCollection;
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetService"/> class.
        /// </summary>
        /// <param name="options"> The MongoDB options </param>
        public BudgetService(IOptions<MongoDatabaseOptions> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var database = mongoClient.GetDatabase(options.Value.Database);
            _budgetCollection = database.GetCollection<Budget>(options.Value.BudgetCollection);
        }
        public async Task<List<BudgetDto>> GetAllAsync()
        {
            var budgets = await _budgetCollection.Find(_ => true).ToListAsync();
            return budgets.Select(budget => budget.ToDto()).ToList();
        }
        public async Task<BudgetDto?> GetByIdAsync(Guid id)
        {
            var budget = await _budgetCollection.Find(budget => budget.Id == id).FirstOrDefaultAsync();
            return budget?.ToDto();
        }
        public async Task<BudgetDto> CreateAsync(BudgetDto budgetDto)
        {
            var budget = budgetDto.ToEntity();
            await _budgetCollection.InsertOneAsync(budget);
            return budget.ToDto();
        }
        public async Task<BudgetDto?> UpdateAsync(Guid id, BudgetDto updatedBudgetDto)
        {
            var budget = await _budgetCollection.Find(b => b.Id == id).FirstOrDefaultAsync();
            if (budget is null)
            {
                return null;
            }
            budget.Name = updatedBudgetDto.Name;
            budget.Income = updatedBudgetDto.Income;
            budget.Expense = updatedBudgetDto.Expense;
            budget.Balance = updatedBudgetDto.Balance;
            budget.Month = updatedBudgetDto.Month;

            await _budgetCollection.ReplaceOneAsync(b => b.Id == id, budget);
            return budget.ToDto();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _budgetCollection.DeleteOneAsync(b => b.Id == id);
            return result.DeletedCount > 0;
        }
    }
}