using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var budgets = await _budgetService.GetBudgetsAsync();

            return Ok(budgets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var budget = await _budgetService.GetBudgetByIdAsync(id);

            if (budget == null)
            {
                return NotFound();
            }

            return Ok(budget);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Budget budget)
        {
            var newBudget = await _budgetService.AddBudgetAsync(budget);

            if (newBudget == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Add), newBudget);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            await _budgetService.DeleteBudgetByIdAsync(id);

            return Ok(id);
        }
    }
}
