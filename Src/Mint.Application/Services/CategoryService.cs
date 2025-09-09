using Microsoft.Extensions.Options;
using Mint.Application.DTOs;
using Mint.Application.Interfaces;
using Mint.Application.Mappings;
using Mint.Application.Options;
using Mint.Domain.Models;
using MongoDB.Driver;

namespace Mint.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryService(IOptions<MongoDatabaseOptions> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var database = mongoClient.GetDatabase(options.Value.Database);
            _categoryCollection = database.GetCollection<Category>(options.Value.CollectionName);
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(_ => true).ToListAsync();
            return categories.Select(category => category.ToDto()).ToList();
        }
        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var category = await _categoryCollection.Find(category => category.Id == id).FirstOrDefaultAsync();
            return category?.ToDto();
        }
        public async Task<CategoryDto> CreateAsync(CategoryDto categoryDto)
        {
            var category = categoryDto.ToEntity();
            await _categoryCollection.InsertOneAsync(category);
            return category.ToDto();
        }
        public async Task<CategoryDto?> UpdateAsync(Guid id, CategoryDto updatedCategoryDto)
        {
            var category = await _categoryCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
            if (category is null)
            {
                return null;
            }
            category.Name = updatedCategoryDto.Name;
            category.Description = updatedCategoryDto.Description;
            category.SetAmount = updatedCategoryDto.SetAmount;
            category.UpdatedAt = DateTime.UtcNow;

            await _categoryCollection.ReplaceOneAsync(c => c.Id == id, category);
            return category.ToDto();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _categoryCollection.DeleteOneAsync(c => c.Id == id);
            return result.DeletedCount > 0;
        }
    }
}