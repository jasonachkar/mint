using Microsoft.AspNetCore.Mvc;
using Mint.Application.DTOs;
using Mint.Application.Interfaces;

namespace Mint.API.Controllers
{
    [ApiController]
    [Route("api/budgets")]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetsController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBudgets()
        {
            var budgets = await _budgetService.GetAllAsync();
            return Ok(budgets);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBudgetById(Guid id)
        {
            var budget = await _budgetService.GetByIdAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBudget([FromBody] BudgetDto budgetDto)
        {
            try
            {
                var createdBudget = await _budgetService.CreateAsync(budgetDto);
                return CreatedAtAction(nameof(GetBudgetById), new { id = createdBudget.Id }, createdBudget);
            }
            catch (Exception ex)
            {
                // Log the exception
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBudget(Guid id, [FromBody] BudgetDto updatedBudget)
        {
            try
            {
                var budget = await _budgetService.UpdateAsync(id, updatedBudget);
                if (budget == null)
                {
                    return NotFound();
                }
                return Ok(budget);
            }
            catch (Exception ex)
            {
                // Log the exception
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBudget(Guid id)
        {
            var deleted = await _budgetService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}