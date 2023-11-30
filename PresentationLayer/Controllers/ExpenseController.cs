using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _expenseService.GetExpensesAsync();

            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByBudget(Guid id)
        {
            var expenses = await _expenseService.GetExpensesByBudgetAsync(id);

            return Ok(expenses);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExpenseDto expense)
        {
            try
            {
                var newExpense = await _expenseService.AddExpenseAsync(expense);

                return CreatedAtAction(nameof(Add), newExpense);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var expense = await _expenseService.DeleteExpenseByIdAsync(id);

                return Ok(expense);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
