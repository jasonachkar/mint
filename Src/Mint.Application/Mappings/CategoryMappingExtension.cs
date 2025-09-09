namespace Mint.Application.Mappings
{
    using Mint.Domain.Models;
    using Mint.Application.DTOs;

    /// <summary>
    /// Extension methods for mapping between Category and CategoryDto.
    /// </summary>
    public static class CategoryMappingExtension
    {
        /// <summary>
        /// Maps a CategoryDto to a Category entity.
        /// </summary>
        /// <param name="dto"> The CategoryDto to be mapped </param>
        /// <returns>A Category Entity <see cref="Category"/> </returns>
        public static Category ToEntity(this CategoryDto dto)
        {
            return new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                SetAmount = dto.SetAmount
            };
        }

        /// <summary>
        /// Maps a Category entity to a CategoryDto.
        /// </summary>
        /// <param name="entity"> The Category entity to be mapped </param>
        /// <returns> A CategoryDto <see cref="CategoryDto"></returns>
        public static CategoryDto ToDto(this Category entity)
        {
            return new CategoryDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                SetAmount = entity.SetAmount
            };
        }
    }
}