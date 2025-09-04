using Microsoft.AspNetCore.Mvc;
using Mint.Application.DTOs;
using Mint.Application.Interfaces;

namespace Mint.API.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController(ITransactionService transactionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await transactionService.GetAllAsync();
            return Ok(transactions);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var transaction = await transactionService.GetByIdAsync(id);
            if (transaction is null)
            {
                return NotFound(new { Success = false, Message = $"Transaction with ID {id} was not found!" });
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionDto transactionDto)
        {
            var createdTransaction = await transactionService.CreateAsync(transactionDto);
            return CreatedAtAction(nameof(GetById), new { id = createdTransaction.Id }, createdTransaction);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TransactionDto updatedTransaction)
        {
            var transaction = await transactionService.UpdateAsync(id, updatedTransaction);
            if (transaction is null)
            {
                return NotFound(new { Success = false, Message = $"Transaction with ID {id} was not found!" });
            }
            return Ok(transaction);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await transactionService.DeleteAsync(id);
            if (!result)
            {
                return NotFound(new { Success = false, Message = $"Transaction with ID {id} was not found!" });
            }
            return NoContent();
        }
    }

}