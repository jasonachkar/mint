using Mint.Domain.Models;
using Mint.Application.DTOs;

namespace Mint.Application.Mappings
{
    /// <summary>
    /// Extension methods for mapping between Transaction and TransactionDto.
    /// </summary>
    public static class TransactionMappingExtension
    {
        /// <summary>
        /// Maps a TransactionDto to a Transaction entity.
        /// </summary>
        /// <param name="dto"> The TransactionDto to be mapped </param>
        /// <returns>A Transaction Entity <see cref="Transaction"/> </returns>
        public static Transaction ToEntity(this TransactionDto dto)
        {
            return new Transaction
            {
                Name = dto.Name,
                Amount = dto.Amount,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                Category = dto.Category
            };
        }

        /// <summary>
        /// Maps a Transaction entity to a TransactionDto.
        /// </summary>
        /// <param name="entity"> The Transaction entity to be mapped </param>
        /// <returns> A TransactionDto <see cref="TransactionDto"></returns>
        public static TransactionDto ToDto(this Transaction entity)
        {
            return new TransactionDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Amount = entity.Amount,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Category = entity.Category
            };
        }
    }
}